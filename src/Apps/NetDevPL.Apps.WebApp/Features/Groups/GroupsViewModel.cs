using System;
using System.Collections.Generic;
using NetDevPL.Features.NetGroups;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.Groups
{
    public class GroupsViewModel: BaseViewModel
    {
        public GroupsViewModel(NetGroupDataSnapshot snapshot)
        {
            GroupsList = snapshot.Groups ?? new List<NetGroup>();

            foreach (var netGroup in GroupsList)
            {
                foreach (var meeting in netGroup.UpcomingMeetings)
                {
                    //TimeZoneInfo.ConvertTimeFromUtc(meeting.Date, TimeZoneInfo.Local)
                    meeting.Date = meeting.Date.ToLocalTime();
                }
            }

            LastUpdate = snapshot.SnapshotDate;
        }

        public List<NetGroup> GroupsList { get; private set; }
        public DateTime LastUpdate { get; set; }
    }
}