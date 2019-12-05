﻿using Jeans.OAuth.Server;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace OAuth.AuthorizationServer.Providers
{
    public class CustomOAuthAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly ICredentialServer _credentialServer;
        private readonly IUserServer _userServer;
        public CustomOAuthAuthorizationServerProvider(
            ICredentialServer credentialServer,
            IUserServer userServer)
        {
            _credentialServer = credentialServer;
            _userServer = userServer;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId, clientSecret;
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            bool result = _credentialServer.HasClientIdAndClientSecret(clientId, clientSecret);
            //这个来自数据库
            if (!result)
            {
                context.SetError("invalid_client", "client or clientSecret is not valid");
                return Task.FromResult<object>(null);
            }

            context.Validated();
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// 密码凭证授予
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (string.IsNullOrEmpty(context.UserName))
            {
                context.SetError("invalid_username", "username is not valid");
                return Task.FromResult<object>(null);
            }
            if (string.IsNullOrEmpty(context.Password))
            {
                context.SetError("invalid_password", "password is not valid");
                return Task.FromResult<object>(null);
            }

            bool result = _userServer.HasLogin(context.UserName, context.Password);
            if (!result)
            {
                context.SetError("invalid_grant", "用户名或密码不正确.");
                return Task.FromResult<object>(null);
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Iphone_Read Iphone_Write"));

            //string role = "Iphone_Read Iphone_Write";
            //var props = new AuthenticationProperties(new Dictionary<string, string>
            //{
            //    {
            //        "scope",role
            //    }
            //});

            //var ticket = new AuthenticationTicket(identity, props);
            //context.Validated(ticket);

            context.Validated(identity);

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// 客户证书授予
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            if (context.Scope.Count <= 0 || (context.Scope.Count == 1 && string.IsNullOrWhiteSpace(context.Scope[0])))
            {
                context.SetError("invalid_scope", "scope 不能为空");
                return Task.FromResult<object>(null);
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Role, string.Join(" ", context.Scope)));

            context.Validated(identity);

            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}