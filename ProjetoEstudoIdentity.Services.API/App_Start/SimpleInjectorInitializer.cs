using Microsoft.Owin;
using ProjetoEstudoIdentity.Infra.CrossCutting.IoC;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web;
using System.Web.Http;
using SimpleInjector.Advanced;

namespace ProjetoEstudoIdentity.Services.API
{
    public static class SimpleInjectorInitializer
    {
        public static void Register(HttpConfiguration config)
        {
            using (var container = new Container())
            {
                container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

                // Chamada dos módulos do Simple Injector
                Bootstrapper.RegisterServices(container);

                // Necessário para registrar o ambiente do Owin que é dependência do Identity
                // Feito fora da camada de IoC para não levar o System.Web para fora
                container.Register(() =>
                {
                    if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying())
                        return new OwinContext().Authentication;
                    return HttpContext.Current.GetOwinContext().Authentication;
                }, Lifestyle.Scoped);

                // This is an extension method from the integration package.
                container.RegisterWebApiControllers(config);

                container.Verify();

                GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            }
        }
    }
}