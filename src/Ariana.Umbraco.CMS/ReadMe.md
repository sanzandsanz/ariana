# PluginManager
# ApplicationEventHandler
# IApplicationEventHandler : 
	Inherting this interface will help you to override the application startup methods
	For Example: We are inheriting this interface in FrameworkEvents.cs

	#ContentLastChanceFinderResolver
	#IContentFinder 

	#Note:
	Content Helper is build on top of UmbracoHelper to access Poco class.
	Where as UmbracoHelper is the helper class to access IPublished Content to work on content.

	#UmbracoOutputCache


	#Read about the CacheBuster: 
	Cache Buster will help to cache the css, javascript so that it don't need to load them again and again from the server




#XmlSitemap.cshtml:

	 There shouldn't be any leading white space before ?xml tag

https://stackoverflow.com/questions/13730460/why-am-i-getting-this-error-about-xml-declaration 


RazorXmlViewPage<T> : WebViewPage<T>

This class is created inheriting the WebViewPage so that we can override the method ExecutePageHierarchy.
The main purpose of this methode is to set the following

 this.Response.ContentType = "application/xml; charset=UTF-8";
 this.Layout = null;

 If we don't set the Response.ContentType, then it will use text content type and we won't be getting the sitemap in the xml format

 Note: Razor use the WebViewPage base class. If we check the web.config files for the View, we have the setting.

  <pages pageBaseType="System.Web.Mvc.WebViewPage">

Since the razor view using the Class, we can so use different properties like Html, Ajax, Model etc to render Html components 

For example: Html.TextBoxFor(), Html.CheckBoxFor() etc.