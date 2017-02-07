namespace NetDevPLWeb.Features.Shared
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            Title = ".NET DevPL";
            Description = ".NET Developers Poland website";
            Url = "http://netdevelopers.pl";
        }

        private string title = ".NET DevPL";

        public string Title { get { return title; } set { title = ".NET DevPL | " + value; } }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}