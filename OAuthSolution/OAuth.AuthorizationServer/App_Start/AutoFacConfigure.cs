using Autofac;
using Autofac.Integration.WebApi;
using Jeans.OAuth.Server;
using OAuth.AuthorizationServer.Providers;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace OAuth.AuthorizationServer
{
    public class AutoFacConfigure
    {
        public static void Configure(IAppBuilder app, HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            Registers(builder);
            var container = builder.Build();
            //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void Registers(ContainerBuilder builder)
        {
            builder.RegisterType<CustomOAuthAuthorizationServerProvider>().AsSelf().SingleInstance();
            builder.RegisterType<CredentialServer>().As<ICredentialServer>();
            builder.RegisterType<UserServer>().As<IUserServer>();
        }
    }
}