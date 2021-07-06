using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab456BigSchool.Startup))]
namespace Lab456BigSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
