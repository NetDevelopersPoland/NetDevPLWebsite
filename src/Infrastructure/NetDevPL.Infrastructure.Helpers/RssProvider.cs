using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace NetDevPL.Infrastructure.Services
{
    public static class RssProvider
    {
        public static IEnumerable<SyndicationItem> GetItemsFromRss(string rssUrl)
        {
            int counter = 0;
            do
            {
                try
                {
                    using (var reader = XmlReader.Create(rssUrl))
                    {
                        var feed = SyndicationFeed.Load(reader);
                        return feed?.Items ?? Enumerable.Empty<SyndicationItem>();
                    }
                }
                catch
                {
                    //TODO log
                }
                counter++;
            } while (counter < 2);

            return Enumerable.Empty<SyndicationItem>();
        }
    }
}