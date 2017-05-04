using System.Collections.Generic;
using Nancy;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.Resources
{
    public class ResourcesViewModel : BaseViewModel
    {
        public ResourcesViewModel(ICollection<Resource> resources, Url url) : base(url)
        {
            ResourcesList = resources;
        }

        public ICollection<Resource> ResourcesList { get; }
    }
}