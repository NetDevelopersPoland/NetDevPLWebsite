using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Nancy;
using Newtonsoft.Json;

namespace NetDevPLWeb.Features.Contributors
{
    public class ContributorsModule : NancyModule
    {
        readonly ContributorsModuleDataSource source = new ContributorsModuleDataSource();

        public ContributorsModule()
        {
            Get["/contributors"] = parameters =>
            {
                var contributors = source.GetContributors();
                return View["contributorsList", new ContributorsListViewModel(contributors)];
            };
        }
    }

    public class ContributorsModuleDataSource
    {
        private readonly Uri _contributorsUrl = new Uri("https://api.github.com/repos/NetDevelopersPoland/NetDevPLWebsite/contributors");

        public List<Contributor> GetContributors()
        {
            var contributors = new List<Contributor>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:43.0) Gecko/20100101 Firefox/43.0");

                var contributorsJson = client.GetStringAsync(_contributorsUrl)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                dynamic response = JsonConvert.DeserializeObject(contributorsJson);

                foreach (var contributor in response)
                {
                    contributors.Add(new Contributor
                    {
                        AvatarUrl = (string) contributor.avatar_url,
                        Name = (string) contributor.login,
                        GithubUrl = (string) contributor.html_url,
                        Contributions = (int) contributor.contributions,
                    });
                }
            }

            return contributors.OrderByDescending(c => c.Contributions).ToList();
        }
    }

    public class Contributor
    {
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public string GithubUrl { get; set; }
        public int Contributions { get; set; }
    }

    public class ContributorsListViewModel
    {
        public ContributorsListViewModel(List<Contributor> contributors)
        {
            Contributors =  contributors;
        }

        public List<Contributor> Contributors { get; set; }
    }
}