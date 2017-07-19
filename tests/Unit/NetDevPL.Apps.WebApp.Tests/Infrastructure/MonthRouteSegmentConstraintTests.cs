using NetDevPLWeb.Infrastructure;
using Xunit;

namespace NetDevPL.Apps.WebApp.Tests.Infrastructure
{
    public class MonthRouteSegmentConstraintTests
    {
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("3", 3)]
        [InlineData("4", 4)]
        [InlineData("5", 5)]
        [InlineData("6", 6)]
        [InlineData("7", 7)]
        [InlineData("8", 8)]
        [InlineData("9", 9)]
        [InlineData("10", 10)]
        [InlineData("11", 11)]
        [InlineData("12", 12)]
        [InlineData("13", -1)]
        [InlineData("", -1)]
        [InlineData(null, -1)]
        [InlineData("aa", -1)]
        [Theory]
        public void TryMatch_CorrectlyParsesData(string month, int expected)
        {
            var monthRouteSegmentConstraint = new MonthRouteSegmentConstraint();

            var match = monthRouteSegmentConstraint.GetMatch("month", month, "month");

            Assert.Equal(expected, match.CapturedParameters["month"]);
        }
    }
}
