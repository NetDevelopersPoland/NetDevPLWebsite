using System.Collections.Generic;
using System.Linq;
using NetDevPL.Features.NetGroups;
using NetDevPL.Infrastructure.Services;
using NetDevPL.Infrastructure.SharedKernel;
using Quartz;

namespace NetDevPLBackgoundJobs.Jobs
{
    internal class NetGroupsUpdateJob : IJob
    {
        private readonly IJsonReader _jsonReader;

        public NetGroupsUpdateJob() : this(new JsonReader()) { }

        internal NetGroupsUpdateJob(IJsonReader jsonReader)
        {
            _jsonReader = jsonReader;
        }

        public void Execute(IJobExecutionContext context)
        {
            var groupsConfig = _jsonReader.ReadAll<NetGroup>("netGroupsConfig.json");

            MeetupDataProvider provider = new MeetupDataProvider();

            var meetings = provider.GetDataFromMeetupPage(groupsConfig);

            AddMeetingsToGroups(groupsConfig, meetings);

            NetGroupDataSnapshot snapshot = NetGroupDataSnapshot.Create();
            snapshot.Groups = groupsConfig;

            Repository repository = new Repository();
            repository.Add(snapshot);

            Logger.Info(string.Format("Found {0} groups with {1} upcoming meetups", snapshot.Groups.Count, snapshot.Groups.SelectMany(g => g.UpcomingMeetings).Count()));
        }

        private void AddMeetingsToGroups(ICollection<NetGroup> groups, ICollection<NetGroupMeeting> meetings)
        {
            foreach (var netGroup in groups)
            {
                netGroup.UpcomingMeetings = meetings.Where(m => m.GroupKey.ToUpper() == netGroup.MeetupName.ToUpper()).ToList();
            }
        }
    }
}