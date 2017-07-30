using System;
using System.Linq.Expressions;

namespace NetDevPL.Features.Facebook
{
    public class PostFilter
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        private string tag;
        public string Tag { get { return tag; } set { tag = value != null ? value.ToLower() : ""; } }

        public bool HasFilter
        {
            get { return StartDate != null || EndDate != null || !String.IsNullOrWhiteSpace(Tag); }
        }

        public bool HasSorting
        {
            get { return SortingExpression != null; }
        }

        public Expression<Func<FacebookPost, object>> SortingExpression { get; set; }
        public SortDirection SortingDirection { get; set; }

        public static PostFilter Empty
        {
            get { return new PostFilter(); }
        }
    }
}