using NetDevPLWeb.Infrastructure;
using Xunit;

namespace NetDevPL.Apps.WebApp.Tests.Infrastructure
{
    public class YearRouteSegmentConstraintTests
    {
        [InlineData("2015", 2015)]
        [InlineData("2016", 2016)]
        [InlineData("2017", 2017)]
        [Theory]
        public void TryMatch_CorrectlyParsesData(string year, int expected)
        {
            var yearRouteSegmentConstraint = new YearRouteSegmentConstraint();

            var match = yearRouteSegmentConstraint.GetMatch("year", year, "year");

            Assert.Equal(expected, match.CapturedParameters["year"]);
        }
    }
}
