using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Students.Web.Startup))]
namespace Students.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
