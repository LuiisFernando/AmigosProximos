using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AmigoProximo.Infra.CrossCutting.IoC;
using AmigoProximo.WebAPI.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

[assembly: OwinStartup(typeof(AmigoProximo.WebAPI.Startup))]

namespace AmigoProximo.WebAPI
{
    public class Startup
    {
        public static Container Container = new Container();

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //Injeção de Dependencia (SimpleInjector)
            Container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            BootStrapper.RegisterServices(Container);

            Container.RegisterSingleton(() =>
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && Container.IsVerifying)
                    return new OwinContext().Authentication;

                return HttpContext.Current.GetOwinContext().Authentication;

            });

            Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            Container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);

            app.UseCors(CorsOptions.AllowAll);

            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationOAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                AllowInsecureHttp = true
            };

            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
