using System;
using System.Collections.Generic;
using Nancy;
using NetDevPL.Features.NetGroups;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.Groups
{
    public class GroupsViewModel : BaseViewModel
    {
        public GroupsViewModel(NetGroupDataSnapshot snapshot, Url url) : base(url)
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

        public ICollection<NetGroup> GroupsList { get; }
        public DateTime LastUpdate { get; set; }
    }
}