using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using OAuth.AuthorizationServer.Providers;
using Owin;
using System;
using System.Web;
using System.Web.Optimization;

namespace OAuth.AuthorizationServer
{
    public class OAuthConfigure
    {
        public static void Configure(IAppBuilder app)
        {
            var oauthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                AuthenticationMode = AuthenticationMode.Active,
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                TokenEndpointPath = new PathString("/token"),
                AuthorizeEndpointPath = new PathString("/authorize"),
                Provider = new CustomOAuthAuthorizationServerProvider(),
                AuthorizationCodeProvider = null,
                RefreshTokenProvider=null
            };

            app.UseOAuthAuthorizationServer(oauthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

    }
}
