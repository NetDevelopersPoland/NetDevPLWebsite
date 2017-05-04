using System.Collections.Generic;

namespace NetDevPLWeb.Features.Resources
{
    public class ResourcesSource
    {
        private readonly IJsonReader _repository;

        public ResourcesSource(IJsonReader repository)
        {
            _repository = repository;
        }

        public ICollection<Resource> GetResources() => _repository.ReadAll<Resource>("Features/Resources/resources.json");
    }
}