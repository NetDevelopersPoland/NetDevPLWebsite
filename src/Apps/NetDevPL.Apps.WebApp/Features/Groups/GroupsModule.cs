using Nancy;
using NetDevPL.Features.NetGroups;

namespace NetDevPLWeb.Features.Groups
{
    public sealed class GroupsModule : NancyModule
    {
        public GroupsModule()
        {
            Get["/groups"] = parameters =>
            {
                Repository repository = new Repository();

                var groupsData = repository.GetGroups();

                return View["groupsList", new GroupsViewModel(groupsData, Request.Url)];
            };
        }
    }
}