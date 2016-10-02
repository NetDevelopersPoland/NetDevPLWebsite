using System.Collections.Generic;
using System.Linq;
using NetDevPL.Features.NetGroups;
using NetDevPL.Infrastructure.Helpers;
using Quartz;

namespace NetDevPLBackgoundJobs.Jobs
{
    internal class NetGroupsUpdateJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var groupsConfig = JsonReaderHelper.ReadObjectListFromJson<NetGroup>("netGroupsConfig.json");

            MeetupDataProvider provider = new MeetupDataProvider();

            var meetings = provider.GetDataFromMeetupPage(groupsConfig);

            AddMeetingsToGroups(groupsConfig, meetings);

            NetGroupDataSnapshot snapshot = NetGroupDataSnapshot.Create();
            snapshot.Groups = groupsConfig;

            Repository repository = new Repository();
            repository.Add(snapshot);
        }

        private void AddMeetingsToGroups(List<NetGroup> groups, List<NetGroupMeeting> meetings)
        {
            foreach (var netGroup in groups)
            {
                netGroup.UpcomingMeetings = meetings.Where(m => m.GroupKey.ToUpper() == netGroup.MeetupName.ToUpper()).ToList();
            }
        }
    }
}