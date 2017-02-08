    <httpRuntime maxRequestLength="1048576" /> It was added to the web.config system.web 
	in order to accept multiple upload of photos

	Keys were added to the web.config file to set the directories
	<add key="PublishersImagesDirectory" value="/images/profiles/"/>
    <add key="PublishersCatalogsDirectory" value="/images/catalogs/" />

	Elmah was added to log any unhandled error.

	 [ChildActionOnly]  it tells the controller that it can only be called as a child method.
	 and it was created to return a partial view because this code is being reused. It is called by 
	 two views, one managed by the Home controller and another managed by the Publisher controller.

        public ActionResult GetCatalogImages(Publisher publisher)
        {

           
        }

  - It was added the returnURl to the Login Link in order to get the user back to the same page.
  @Html.ActionLink("Log in", "Login", "Account", routeValues: new { @returnUrl = ViewContext.HttpContext.Request.Url.PathAndQuery }, htmlAttributes: new { id = "loginLink", @class = "PhotobookHome" })</li>


  - //Added by me in order to get more information about the user into the RegisterViewModel
        [Required]
        [StringLength(15, ErrorMessage = "It can't be more than 15 chars long")]
        public string NickName { get; set; }

- For migrations I have separated the photobook context from the identity context so, they will have
different migration directory and config files 
PM> Enable-Migrations -ContextTypeName PhotoBook.DBContexts.PhotoBookContext  -MigrationsDirectory "Migrations\PhotoBookContext"
PM>Enable-Migrations -ContextTypeName PhotoBook.Models.ApplicationDbContext  -MigrationsDirectory "Migrations\IdentityContext"
PM>Add-migration -ConfigurationTypeName ConfigIdentity "Initial2"
PM> Update-Database -ConfigurationTypeName ConfigIdentity
Add-migration -ConfigurationTypeName ConfigPhoto "CommentsModified"

-In the Startup.cs file, I have added a method called CreateRolesAndUsers. This will be used to create the Admin role and 
the initial account to maintain the website.


- Added LightBox to add effect to the image gallery
