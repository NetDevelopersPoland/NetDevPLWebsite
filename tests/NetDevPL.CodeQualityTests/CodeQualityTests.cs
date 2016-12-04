using Gmtl.CodeWatch;
using Gmtl.CodeWatch.Watchers;
using Xunit;

namespace NetDevPL.CodeQualityTests
{
    public class CodeQualityTests
    {
        [Fact]
        public void PropertyNamesShouldStartWithUppercase()
        {
            CodeWatcherConfig config = CodeWatcherConfig.Create()
                .WithWatcher(ctx => new PropertyNamingWatcher().Configure(Naming.UpperCase))
                .WatchAssembly(typeof(NetDevPLWeb.Program).Assembly)
                .WatchAssembly(typeof(NetDevPLBackgoundJobs.Program).Assembly)
                .WatchAssembly(typeof(NetDevPL.Features.Blogs.Blog).Assembly)
                .WatchAssembly(typeof(NetDevPL.Features.Facebook.FacebookPost).Assembly)
                .WatchAssembly(typeof(NetDevPL.Features.NetGroups.Group).Assembly)
                .WatchAssembly(typeof(NetDevPL.Infrastructure.Helpers.RssProvider).Assembly)
                .WatchAssembly(typeof(NetDevPL.Infrastructure.MongoDB.MongoDBProvider<object>).Assembly)
                .WatchAssembly(typeof(NetDevPL.Infrastructure.SharedKernel.Logger).Assembly)
                .WatchAssembly(typeof(NetDevPL.Features.NetGroups.IntegrationTests.MeetupDataProviderTests).Assembly)

                //Types below are skipped till json mapping/attributes are added there
                .SkipType(typeof(NetDevPL.Features.NetGroups.Group))
                .SkipType(typeof(NetDevPL.Features.NetGroups.Meta))
                .SkipType(typeof(NetDevPL.Features.NetGroups.RootObject))
                .SkipType(typeof(NetDevPL.Features.NetGroups.Venue))
                .SkipType(typeof(NetDevPL.Features.NetGroups.Result))
                .Build();

            config.Execute();
        }
    }
}