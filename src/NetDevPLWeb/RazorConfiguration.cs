using System.Collections.Generic;
using Nancy.ViewEngines.Razor;

namespace NetDevPLWeb
{
    public class RazorConfiguration: IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            yield return "Gmtl.HandyLib";
            yield return "NetDevPLWeb.Features.Facebook";
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            yield return "Gmtl.HandyLib";
            yield return "NetDevPLWeb.Features.Facebook";
        }

        public bool AutoIncludeModelNamespace => true;
    }
}