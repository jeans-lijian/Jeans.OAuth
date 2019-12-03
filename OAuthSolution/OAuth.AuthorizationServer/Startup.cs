using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OAuth.AuthorizationServer.Startup))]

namespace OAuth.AuthorizationServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            OAuthConfigure.Configure(app);

            app.UseWebApi(config);
        }
    }
}
