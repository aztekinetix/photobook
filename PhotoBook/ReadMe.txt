    <httpRuntime maxRequestLength="1048576" /> It was added to the web.config system.web 
	in order to accept multiple upload of photos

	Keys were added to the web.config file to set the directories
	<add key="PublishersImagesDirectory" value="/images/profiles/"/>
    <add key="PublishersCatalogsDirectory" value="/images/catalogs/" />

	Elmah was added to log any unhandled error.