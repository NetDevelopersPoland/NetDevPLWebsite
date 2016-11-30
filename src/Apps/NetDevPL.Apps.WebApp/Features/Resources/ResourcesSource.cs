using System.Collections.Generic;
using NetDevPL.Infrastructure.Helpers;

namespace NetDevPLWeb.Features.Resources
{
    public class ResourcesSource
    {
        public List<Resource> GetResources() => JsonReaderHelper.ReadObjectListFromJson<Resource>("Features/Resources/resources.json");
    }
}