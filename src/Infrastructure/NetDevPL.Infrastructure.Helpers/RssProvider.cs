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
                XmlReader reader = XmlReader.Create(rssUrl);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();

                return feed?.Items ?? Enumerable.Empty<SyndicationItem>();
            }
            catch
            {
                return Enumerable.Empty<SyndicationItem>();
            }            
        }
    }
}
