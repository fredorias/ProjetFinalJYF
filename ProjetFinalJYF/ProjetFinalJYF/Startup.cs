using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetFinalJYF.Startup))]
namespace ProjetFinalJYF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
