// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="MeetupDataProvider.cs" project="NetDevPL.Features.NetGroups" date="2016-09-29 07:46">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using RestSharp;

namespace NetDevPL.Features.NetGroups
{
    public class MeetupDataProvider
    {
        private static Dictionary<string, string> meetupPagesToCheck = new Dictionary<string, string>()
        {
            {"wrocnet","Wrocław"},
            {"rg-dev","Rzeszów"},
            {"KGD-NET","Kraków"},
            {"WG-NET","Warszawa"},
            {"Lodz-NET-IT-Pro-User-Group","Łódź"},
            {"DEV-ZG","Zielona Góra"}
        };

        public List<MeetupData> GetDataFromMeetupPage()
        {
            string meetupApiKey = ConfigurationManager.AppSettings["MeetupApiKey"];
            var meetupData = new List<MeetupData>();
            var client = new RestClient("https://api.meetup.com");

            foreach (var pair in meetupPagesToCheck)
            {
                var request = new RestRequest("/2/events", Method.GET);
                request.AddQueryParameter("group_urlname", pair.Key);

                request.AddQueryParameter("key", meetupApiKey);
                request.AddQueryParameter("sign", "true");

                var result = client.Get<RootObject>(request);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var data = result.Data.results.FirstOrDefault(r => r.status == "upcoming");

                    if (data != null)
                    {
                        MeetupData record = new MeetupData
                        {
                            City = pair.Value,
                            Title = data.name,
                            Link= data.event_url,
                            Description = data.description,
                            Date = Gmtl.HandyLib.HLDateTime.FromUnixTimestamp((data.utc_offset + data.time) / 1000),
                            Limit = data.yes_rsvp_count + "/" + ((data.rsvp_limit > 0) ? data.rsvp_limit : 999)
                        };

                        meetupData.Add(record);
                    }
                }
            }

            return meetupData;
        }
    }

    public class Venue
    {
        public string country { get; set; }
        public string localized_country_name { get; set; }
        public string city { get; set; }
        public string address_1 { get; set; }
        public string name { get; set; }
        public double lon { get; set; }
        public int id { get; set; }
        public double lat { get; set; }
        public bool repinned { get; set; }
    }

    public class Group
    {
        public string join_mode { get; set; }
        public long created { get; set; }
        public string name { get; set; }
        public double group_lon { get; set; }
        public int id { get; set; }
        public string urlname { get; set; }
        public double group_lat { get; set; }
        public string who { get; set; }
    }

    public class Result
    {
        public int utc_offset { get; set; }
        public Venue venue { get; set; }
        public int rsvp_limit { get; set; }
        public int headcount { get; set; }
        public string visibility { get; set; }
        public int waitlist_count { get; set; }
        public long created { get; set; }
        public int maybe_rsvp_count { get; set; }
        public string description { get; set; }
        public string how_to_find_us { get; set; }
        public string event_url { get; set; }
        public int yes_rsvp_count { get; set; }
        public bool announced { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public long time { get; set; }
        public long updated { get; set; }
        public Group group { get; set; }
        public string status { get; set; }
    }

    public class Meta
    {
        public string next { get; set; }
        public string method { get; set; }
        public int total_count { get; set; }
        public string link { get; set; }
        public int count { get; set; }
        public string description { get; set; }
        public string lon { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string signed_url { get; set; }
        public string id { get; set; }
        public long updated { get; set; }
        public string lat { get; set; }
    }

    public class RootObject
    {
        public List<Result> results { get; set; }
        public Meta meta { get; set; }
    }

    public class MeetupData
    {
        public string Description { get; set; }
        public string City { get; set; }
        public string Title { get; set; }
        public string Limit { get; set; }
        public string Link { get; set; }
        public DateTime Date { get; set; }
    }
}