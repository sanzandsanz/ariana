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
