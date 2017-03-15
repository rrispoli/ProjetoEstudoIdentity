using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.WebApi;
using System.Web;
using Microsoft.Owin;
using ProjetoEstudoIdentity.Infra.CrossCutting.IoC;

[assembly: WebActivator.PostApplicationStartMethod(typeof(ProjetoEstudoIdentity.Services.API.SimpleInjectorWebApiInitializer), "Initialize")]

namespace ProjetoEstudoIdentity.Services.API
{
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // Chamada dos módulos do Simple Injector
            InitializeContainer(container);

            // Necessário para registrar o ambiente do Owin que é dependência do Identity
            // Feito fora da camada de IoC para não levar o System.Web para fora
            container.Register(() =>
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying())
                {
                    return new OwinContext().Authentication;
                }
                return HttpContext.Current.GetOwinContext().Authentication;
            }, Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            Bootstrapper.RegisterServices(container);
        }
    }
}