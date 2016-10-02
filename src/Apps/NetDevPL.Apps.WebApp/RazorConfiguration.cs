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
            yield return "NetDevPL.Features.NetGroups";
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            yield return "Gmtl.HandyLib";
            yield return "NetDevPLWeb.Features.Facebook";
            yield return "NetDevPLWeb.Features.Groups";
        }

        public bool AutoIncludeModelNamespace => true;
    }
}