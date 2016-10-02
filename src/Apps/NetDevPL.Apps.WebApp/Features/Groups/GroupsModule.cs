using System;
using System.Collections.Generic;
using Nancy;
using NetDevPL.Features.NetGroups;

namespace NetDevPLWeb.Features.Groups
{
    public class GroupsModule : NancyModule
    {
        public GroupsModule()
        {
            Get["/groups"] = parameters =>
            {
                Repository repository = new Repository();

                var groupsData = repository.GetGroups();

                return View["groupsList", new GroupsViewModel(groupsData)];
            };
        }
    }
    
    public class GroupsViewModel
    {
        public GroupsViewModel(NetGroupDataSnapshot snapshot)
        {
            GroupsList = snapshot.Groups;
            LastUpdate = snapshot.SnapshotDate;
        }

        public List<NetGroup> GroupsList { get; private set; }
        public DateTime LastUpdate { get; set; }
    }
}