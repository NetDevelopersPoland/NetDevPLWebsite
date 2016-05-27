using Nancy;
using Nancy.Conventions;

namespace NetDevPLWeb
{
    public class CustomConventionsBootstrapper : DefaultNancyBootstrapper
    {
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
    }
}