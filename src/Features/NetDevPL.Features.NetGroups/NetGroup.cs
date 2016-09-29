// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="NetGroup.cs" project="NetDevPL.Features.NetGroups" date="2016-09-29 23:06">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

using System;

namespace NetDevPL.Features.NetGroups
{
    public class NetGroup
    {
        public string Name { get; set; }
        public string MeetupName { get; set; }
        public string City { get; set; }
        public string WebSite { get; set; }
        public NetGroupMeeting NextMeeting { get; set; }
    }

    public class NetGroupMeeting
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public string Limit { get; set; }
        public string Link { get; set; }
        public DateTime Date { get; set; }
    }
}