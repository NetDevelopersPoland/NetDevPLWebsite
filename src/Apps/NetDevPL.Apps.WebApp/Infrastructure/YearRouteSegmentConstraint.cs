using Nancy.Routing.Constraints;
using System;

namespace NetDevPLWeb.Infrastructure
{
    public class YearRouteSegmentConstraint : RouteSegmentConstraintBase<int>
    {
        public override string Name => "year";

        protected override bool TryMatch(string constraint, string segment, out int matchedValue)
        {
            var now = DateTime.Now;

            int year;
            int.TryParse(segment, out year);
            year = (year < 2015 || year > now.Year) ? now.Year : year;
            matchedValue = year;
            return true;
        }
    }
}
