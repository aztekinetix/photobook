using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhotoBook.Startup))]
namespace PhotoBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
