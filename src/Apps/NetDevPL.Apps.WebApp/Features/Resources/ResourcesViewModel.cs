using System.Collections.Generic;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.Resources
{
    public class ResourcesViewModel : BaseViewModel
    {
        public ResourcesViewModel(List<Resource> resources)
        {
            ResourcesList = resources;
        }

        public List<Resource> ResourcesList { get; private set; }
    }
}