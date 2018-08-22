using System.Collections.Concurrent;
using System.ComponentModel;
using System.Web;
using Our.Umbraco.Ditto;
using Umbraco.Core.Configuration;
using Umbraco.Core.Configuration.UmbracoSettings;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Routing;
using Umbraco.Web.Security;

namespace Ariana.Umbraco.Helpers
{
    using Ariana.Umbraco.CMS.Models;
    using global::Umbraco.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ContentHelper
    {

        /// <summary>
        /// A new instance Initializes a new instance of the <see cref="ContentHelper"/> class.
        /// with lazy initialization.
        /// </summary>
        private static readonly Lazy<ContentHelper> Lazy = new Lazy<ContentHelper>(() => new ContentHelper());

        /// <summary>
        /// Gets the current instance of the <see cref="ContentHelper"/> class.
        /// </summary>
        public static ContentHelper Instance => Lazy.Value;

        /// <summary>
        /// The collection of registered types.
        /// </summary>
        private static readonly ConcurrentDictionary<string, Type> RegisteredTypes
            = new ConcurrentDictionary<string, Type>(StringComparer.InvariantCultureIgnoreCase);

        /// <summary>
        /// Prevents a default instance of the <see cref="ContentHelper"/> class from being created.
        /// </summary>
        private ContentHelper()
        {
            List<Type> registerTypes = PluginManager.Current.ResolveTypes<Page>().ToList();
            registerTypes.AddRange(PluginManager.Current.ResolveTypes<NestedComponent>());

            foreach (Type type in registerTypes)
            {
                this.RegisterType(type);
            }
        }

        /// <summary>
        /// Registers the given type to allow conversion.
        /// </summary>
        /// <param name="type">The type to register.</param>
        /// <param name="alias">Any alias for the given type.</param>
        public void RegisterType(Type type, string alias = null)
        {
            RegisteredTypes.GetOrAdd(type.Name, t => type);
        }


        /// <summary>
        /// Gets the stored type matching the given name.
        /// </summary>
        /// <param name="name">The name of the type to retrieve.</param>
        /// <returns>
        /// The stored <see cref="Type"/>.
        /// </returns>
        public Type GetRegisteredType(string name)
        {
            Type type;
            RegisteredTypes.TryGetValue(name, out type);
            return type;
        }


        //Todo: Need caching implementation
        public int GetHomeId()
        {
            string hostName = HttpContext.Current.Request.Url.DnsSafeHost;
            int homeId = 0;
            if (homeId == 0)
            {
                IDomainService ds = ApplicationContext.Current.Services.DomainService;
                IList<IDomain> domains = ds.GetAll(true) as IList<IDomain> ?? ds.GetAll(true).ToList();
                IDomain domain = domains.FirstOrDefault(d => d.DomainName.InvariantStartsWith(hostName));

                homeId = (int)domain.RootContentId;
            }

            return homeId;
        }





        /// <summary>
        /// Filters and parses a given item from the published content. If an interface is passed the type implementing that
        /// interface will be returned.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <param name="content">The <see cref="IPublishedContent"/>.</param>
        /// <returns>
        /// The given type instance.
        /// </returns>
        private T FilterAndParse<T>(IPublishedContent content)
        {
            if (content == null)
            {
                return default(T);
            }

            Type returnType = typeof(T);
            bool isInterface = returnType.IsInterface;

            // Filter the collection if necessary.
            if (!isInterface && returnType != typeof(Page) && returnType != typeof(Component))
            {
                string name = returnType.Name;
                if (!content.DocumentTypeAlias.InvariantEquals(name))
                {
                    return default(T);
                }
            }

            // If we are passed a an interface then we want to return the type that implement that interface.
            if (isInterface)
            {
                Type type = this.GetRegisteredType(content.DocumentTypeAlias);

                if (type != null && returnType.IsAssignableFrom(type))
                {
                    object meta = content.As(type);
                    if (meta != null)
                    {
                        return (T)meta;
                    }
                }
            }
            else
            {
                Type type = this.GetRegisteredType(content.DocumentTypeAlias);

                if (type != null)
                {
                    object meta = content.As(type);
                    if (meta != null)
                    {
                        return (T)meta;
                    }
                }
            }

            return default(T);
        }

        /// <summary>
        /// Gets the current active Site node that determines which site we should be loading content for.
        /// </summary>
        /// <returns></returns>
        public T GetSite<T>()
            where T : class
        {
            T site = this.GetHome<Page>().Ancestors<T>().FirstOrDefault();
            if (site != null)
            {
                return site;
            }
            return default(T);
        }



        /// <summary>
        /// Gets the current Home node of a specific type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetHome<T>()
            where T : class
        {
            return this.GetById<T>(this.GetHomeId());
        }



        /// <summary>
        /// Gets the node matching the given id.
        /// </summary>
        /// <param name="nodeId">The id of the node to return.</param>
        /// <returns>
        /// The <see cref="Page"/> matching the id.
        /// </returns>
        public Page GetById(int nodeId) => this.GetById<Page>(nodeId);

        /// <summary>
        /// Gets the node matching the given id.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <param name="nodeId">The id of the node to return.</param>
        /// <returns>
        /// The given <see cref="Type"/> instance matching the id.
        /// </returns>
        public T GetById<T>(int nodeId)
            where T : class
        {
            return this.FilterAndParse<T>(this.UmbracoHelper.TypedContent(nodeId));
        }


        /// <summary>
        /// Gets the <see cref="UmbracoHelper"/> for querying published content or media.
        /// </summary>
        public UmbracoHelper UmbracoHelper
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    // Pull the item from the cache if possible to reduce the overhead for multiple operations
                    // taking place in a single request
                    return (UmbracoHelper)ApplicationContext.Current.ApplicationCache.RequestCache.GetCacheItem(
                        "ContentHelper.Instance.UmbracoHelper",
                        () =>
                        {
                            HttpContextBase context = new HttpContextWrapper(HttpContext.Current);
                            ApplicationContext application = ApplicationContext.Current;
                            WebSecurity security = new WebSecurity(context, application);
                            IUmbracoSettingsSection umbracoSettings = UmbracoConfig.For.UmbracoSettings();
                            IEnumerable<IUrlProvider> providers = UrlProviderResolver.Current.Providers;
                            return new UmbracoHelper(UmbracoContext.EnsureContext(context, application, security, umbracoSettings, providers, false));
                        });
                }

                return FallbackUmbracoHelper;
            }
        }


        /// <summary>
        /// Gets or sets the fallback <see cref="UmbracoHelper"/>.
        /// This is assigned during application initialization.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static UmbracoHelper FallbackUmbracoHelper { get; set; }


        /// <summary>
        /// Gets the ancestors of the current instance as the given <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <param name="nodeId">The id of the current node to search from.</param>
        /// <param name="maxLevel">The maximum level to search.</param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public IEnumerable<T> GetAncestors<T>(int nodeId, int maxLevel = int.MaxValue)
        {
            return this.FilterAndParseCollection<T>(this.UmbracoHelper.TypedContent(nodeId).Ancestors(maxLevel));
        }


        /// <summary>
        /// Filters and parses the collection of published content to return a collection of the given type.
        /// If an interface is passed then types implementing that interface will be returned.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <param name="contentList">The collection of <see cref="IPublishedContent"/></param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        private IEnumerable<T> FilterAndParseCollection<T>(IEnumerable<IPublishedContent> contentList)
        {
            // Prevent multiple enumeration.
            IEnumerable<IPublishedContent> publishedContent = contentList as IPublishedContent[] ?? contentList.ToArray();
            if (!publishedContent.Any())
            {
                yield break;
            }

            Type returnType = typeof(T);
            bool isInterface = returnType.IsInterface;

            // Filter the collection if necessary.
            if (!isInterface && returnType != typeof(Page) && returnType != typeof(Component))
            {
                string name = returnType.Name;
                publishedContent = publishedContent.Where(c => c.DocumentTypeAlias.InvariantEquals(name));
            }

            // If we are passed a an interface then we want to return all types that implement that interface.
            if (isInterface)
            {
                foreach (IPublishedContent content in publishedContent)
                {
                    Type type = this.GetRegisteredType(content.DocumentTypeAlias);

                    if (type != null && returnType.IsAssignableFrom(type))
                    {
                        object meta = content.As(type);
                        if (meta != null)
                        {
                            yield return (T)meta;
                        }
                    }
                }
            }
            else
            {
                foreach (IPublishedContent content in publishedContent)
                {
                    Type type = this.GetRegisteredType(content.DocumentTypeAlias);

                    if (type != null)
                    {
                        object meta = content.As(type);
                        if (meta != null)
                        {
                            yield return (T)meta;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Gets the children of the current instance as the given <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <param name="nodeId">The id of the current node to search from.</param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public IEnumerable<T> GetChildren<T>(int nodeId)
        {
            return this.FilterAndParseCollection<T>(this.UmbracoHelper.TypedContent(nodeId).Children);
        }
    }
}
