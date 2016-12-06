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
                .WatchAssembly(typeof(Features.Blogs.Blog).Assembly)
                .WatchAssembly(typeof(Features.Facebook.FacebookPost).Assembly)
                .WatchAssembly(typeof(Features.NetGroups.Group).Assembly)
                .WatchAssembly(typeof(Infrastructure.Helpers.RssProvider).Assembly)
                .WatchAssembly(typeof(Infrastructure.MongoDB.MongoDBProvider<object>).Assembly)
                .WatchAssembly(typeof(Infrastructure.SharedKernel.Logger).Assembly)
                .WatchAssembly(typeof(Features.NetGroups.IntegrationTests.MeetupDataProviderTests).Assembly)

                //Types below are skipped till json mapping/attributes are added there
                .SkipType(typeof(Features.NetGroups.Group))
                .SkipType(typeof(Features.NetGroups.Meta))
                .SkipType(typeof(Features.NetGroups.RootObject))
                .SkipType(typeof(Features.NetGroups.Venue))
                .SkipType(typeof(Features.NetGroups.Result))
                .Build();

            config.Execute();
        }
    }
}