using Jeans.OAuth.Server;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OAuth.AuthorizationServer.Providers
{
    public class CustomOAuthAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public ICredentialServer CredentialServer { get; set; }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId, clientSecret;
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            bool result = CredentialServer.ValidateClientIdAndClientSecret(clientId, clientSecret);
            //这个来自数据库
            if (!result)
            {
                context.SetError("invalid_client", "client or clientSecret is not valid");
                return;
            }

            context.Validated();
        }
    }
}