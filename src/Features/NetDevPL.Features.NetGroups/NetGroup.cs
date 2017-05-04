// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="NetGroup.cs" project="NetDevPL.Features.NetGroups" date="2016-09-29 23:06">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace NetDevPL.Features.NetGroups
{
    /// <summary>
    ///     State of .net groups data in Poland at certain date
    /// </summary>
    public class NetGroupDataSnapshot
    {
        /// <summary>
        ///     Actual .net groups
        /// </summary>
        public ICollection<NetGroup> Groups { get; set; }

        /// <summary>
        ///     Date when snapshot was taken
        /// </summary>
        public DateTime SnapshotDate { get; set; }

        public static NetGroupDataSnapshot Create()
        {
            return new NetGroupDataSnapshot {SnapshotDate = DateTime.Now};
        }
    }

    public class NetGroup
    {
        public string Name { get; set; }
        public string MeetupName { get; set; }
        public string City { get; set; }
        public string WebSite { get; set; }
        public List<NetGroupMeeting> UpcomingMeetings { get; set; }
    }

    public class NetGroupMeeting
    {
        public string GroupKey { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public NetGroupMeetingSeat Seat { get; set; }
        public string Link { get; set; }
        public DateTime Date { get; set; }
    }

    public class NetGroupMeetingSeat
    {
        public int CurrentNumber { get; set; }
        public int TotalNumber { get; set; }
    }
}