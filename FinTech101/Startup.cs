using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinTech101.Startup))]
namespace FinTech101
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
