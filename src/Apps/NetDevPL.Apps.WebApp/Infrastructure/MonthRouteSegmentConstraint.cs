using Nancy.Routing.Constraints;
using System;

namespace NetDevPLWeb.Infrastructure
{
    public class MonthRouteSegmentConstraint : RouteSegmentConstraintBase<int?>
    {
        public override string Name => "month";

        protected override bool TryMatch(string constraint, string segment, out int? matchedValue)
        {
            int month = -1;
            int.TryParse(segment, out month);
            month = ((month < 1 || month > 12) && month != -1) ? -1 : month;
            matchedValue = month;

            return true;
        }
    }
}
