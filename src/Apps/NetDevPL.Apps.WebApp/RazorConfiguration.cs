using System.Collections.Generic;
using Nancy.ViewEngines.Razor;

namespace NetDevPLWeb
{
    public class RazorConfiguration : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            yield return "Gmtl.HandyLib";
            yield return "NetDevPL.Features.Facebook";
            yield return "NetDevPL.Features.NetGroups";
            yield return "NetDevPL.Features.Blogs";
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            yield return "Gmtl.HandyLib";
            yield return "NetDevPLWeb.Features.Facebook";
            yield return "NetDevPLWeb.Features.Groups";
            yield return "NetDevPLWeb.Features.Blogs";
        }

        public bool AutoIncludeModelNamespace => true;
    }
}