using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;

namespace OAuth.AuthorizationServer.Providers
{
    public class CustomRefreshTokenProvider : AuthenticationTokenProvider
    {
        public override Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            //生成的刷新Token可以存储到数据库
            context.SetToken(context.SerializeTicket());
            return Task.FromResult(0);
        }

        public override Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            //刷新token时，先从数据库删除
            context.DeserializeTicket(context.Token);
            return Task.FromResult(0);
        }
    }
}