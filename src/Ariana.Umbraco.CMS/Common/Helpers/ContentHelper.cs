using System.Collections.Concurrent;

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


    }
}
