using System.Collections.Generic;

namespace NetDevPLWeb.Features.Resources
{
    public class ResourcesViewModel
    {
        public ResourcesViewModel(List<Resource> resources)
        {
            ResourcesList = resources;
        }

        public List<Resource> ResourcesList { get; private set; }
    }
}