using System;
using Microsoft.Owin;
using Owin;
using PhotoBook.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(PhotoBook.Startup))]
namespace PhotoBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        
        }

        private void CreateRolesAndUsers()
        {
            //getting the Application Context where Identity Framework is working
            ApplicationDbContext context = new ApplicationDbContext();

            // In order to create users and roles we need to instantiate the proper managers
            //I am telling to the managers which context contains the information about users and roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //let's create the role of semiGod, because God is only one :)
            if (!roleManager.RoleExists("Admin")) // if it doesn't exist, create it for me
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser { UserName = "Administrator", Email = "administrator@photobook.com", PasswordHash=new PasswordHasher().HashPassword("Il0vei*net") };
               // string pwd = "Ilovei*net";
                var result = userManager.Create(user);
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }

            }
        }
    }
}
