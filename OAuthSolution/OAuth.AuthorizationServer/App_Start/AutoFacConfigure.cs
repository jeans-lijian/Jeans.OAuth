using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Jeans.OAuth.Data;
using Jeans.OAuth.Server;
using OAuth.AuthorizationServer.Providers;
using Owin;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace OAuth.AuthorizationServer
{
    public class AutoFacConfigure
    {
        public static void Configure(IAppBuilder app, HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            Registers(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void Registers(ContainerBuilder builder)
        {
            builder.RegisterType<MySqlDbContext>().As<IDbContext>().SingleInstance();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).SingleInstance();

            builder.RegisterType<CustomOAuthAuthorizationServerProvider>().AsSelf().SingleInstance();
            builder.RegisterType<CredentialServer>().As<ICredentialServer>();
            builder.RegisterType<UserServer>().As<IUserServer>();
        }
    }
}