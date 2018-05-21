using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(finalProject_Kramar.Startup))]
namespace finalProject_Kramar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
