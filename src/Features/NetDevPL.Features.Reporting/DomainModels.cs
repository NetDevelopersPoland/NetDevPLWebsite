using System;
using System.Collections.Generic;

namespace NetDevPL.Features.Reporting
{
    public class KarmaReport
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IList<UserKarma> TopUsers { get; set; }
    }

    public class UserKarma
    {
        public string Name { get; set; }
        public int LinesCount { get; set; }
        public int CommentsCount { get; set; }
        public int Karma { get { return LinesCount + CommentsCount; } }
    }
}