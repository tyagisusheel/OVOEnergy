using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VCharge.Startup))]
namespace VCharge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
