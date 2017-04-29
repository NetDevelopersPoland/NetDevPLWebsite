using System;
using System.Configuration;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.SimpleAuthentication;
using Nancy.TinyIoc;
using NetDevPLWeb.Infrastructure;
using SimpleAuthentication.Core;
using SimpleAuthentication.Core.Providers;

namespace NetDevPLWeb
{
    public class CustomConventionsBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);
            container.Register<IUserMapper, FormsUser>();
            var options = new ConfigurationOptions
            {
                BasePath = new Uri("http://netdevelopers.pl")
            };
            container.Register<IConfigurationOptions>(options);
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            var formsAuthConfiguration = new FormsAuthenticationConfiguration
            {
                RedirectUrl = "~/login",
                UserMapper = container.Resolve<IUserMapper>()
            };

            FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.ViewLocationConventions.Clear();

            nancyConventions.ViewLocationConventions.Add(
                (viewName, model, viewLocationContext) =>
                    "features/" + viewLocationContext.ModuleName + "/Views/" + viewName);

            nancyConventions.ViewLocationConventions.Add(
                (viewName, model, viewLocationContext) =>
                    "features/Shared/Views/" + viewName);
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            // var twitterProvider = new TwitterProvider(new ProviderParams { PublicApiKey = ConfigurationManager.AppSettings["TwitterApiId"], SecretApiKey = ConfigurationManager.AppSettings["TwitterApiSecret"] });
            var facebookProvider = new FacebookProvider(new ProviderParams { PublicApiKey = ConfigurationManager.AppSettings["FacebookApiId"], SecretApiKey = ConfigurationManager.AppSettings["FacebookApiSecret"] });
            //var googleProvider = new GoogleProvider(new ProviderParams { PublicApiKey = ConfigurationManager.AppSettings["GoogleApiId"], SecretApiKey = ConfigurationManager.AppSettings["GoogleApiSecret"] });

            AuthenticationProviderFactory providerFactory = new AuthenticationProviderFactory();
            
            // providerFactory.AddProvider(twitterProvider);
            providerFactory.AddProvider(facebookProvider);
            // providerFactory.AddProvider(googleProvider);
            container.Register<IAuthenticationCallbackProvider>(new SampleAuthenticationCallbackProvider());
        }
    }
}