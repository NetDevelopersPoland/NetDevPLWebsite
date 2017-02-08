using Nancy;

namespace NetDevPLWeb.Features.Shared
{
    public class BaseViewModel
    {
        public BaseViewModel(Url url)
        {
            Title = "Strona główna";
            Description = ".NET Developers Poland website";
            Url = CreateCanonicUrl(url);
        }

        private string CreateCanonicUrl(Url url)
        {
            return url.ToString();
        }

        private string title = ".NET DevPL";

        public string Title { get { return title; } set { title = ".NET DevPL | " + value; } }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}