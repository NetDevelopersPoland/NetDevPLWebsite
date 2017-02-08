using System.Collections.Generic;
using Nancy;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.Resources
{
    public class ResourcesViewModel : BaseViewModel
    {
        public ResourcesViewModel(List<Resource> resources, Url url) : base(url)
        {
            ResourcesList = resources;
        }

        public List<Resource> ResourcesList { get; private set; }
    }
}