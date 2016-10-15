using Gmtl.CodeWatch;
using Xunit;

namespace NetDevPL.CodeQualityTests
{
    public class CodeQualityTests
    {
        [Fact]
        public void PropertyNamesShouldStartWithUppercase()
        {
            PropertyNamingWatcher watcher = new PropertyNamingWatcher();
            watcher.Configure(Naming.UpperCase);
            watcher.WatchAssembly(typeof(NetDevPLWeb.Program).Assembly);
            watcher.WatchAssembly(typeof(NetDevPLBackgoundJobs.Program).Assembly);

            watcher.Execute();
        }
    }
}