using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MailBoxSytem.Startup))]
namespace MailBoxSytem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
