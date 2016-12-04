using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace NetDevPL.Infrastructure.Helpers
{
    public static class RssProvider
    {
        public static IEnumerable<SyndicationItem> GetItemsFromRss(string rssUrl)
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
                return Enumerable.Empty<SyndicationItem>();
            }
        }
    }
}