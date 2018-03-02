using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviesAutentication.Startup))]
namespace MoviesAutentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
