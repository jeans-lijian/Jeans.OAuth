using Autofac;
using Autofac.Integration.WebApi;
using Jeans.OAuth.Server;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using OAuth.AuthorizationServer.Providers;
using Owin;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;

namespace OAuth.AuthorizationServer
{
    public class OAuthConfigure
    {
        public static void Configure(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType= "Application",
                AuthenticationMode= AuthenticationMode.Passive,
                LoginPath=new PathString("/Account/Login"),
                LogoutPath=new PathString("/Account/LoginOut")
            });

            var oauthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                AuthenticationMode = AuthenticationMode.Active,
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                TokenEndpointPath = new PathString("/token"),
                AuthorizeEndpointPath = new PathString("/authorize"),
                Provider = GlobalConfiguration.Configuration.DependencyResolver.GetRootLifetimeScope().Resolve<CustomOAuthAuthorizationServerProvider>(),
                AuthorizationCodeProvider = null,
                RefreshTokenProvider = null,
                AccessTokenProvider= new CustomAccessTokenProvider()
            };

            app.UseOAuthAuthorizationServer(oauthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

    }
}
