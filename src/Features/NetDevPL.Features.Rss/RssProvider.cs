using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;

namespace NetDevPL.Features.Rss
{
    public class RssProvider
    {
        public IEnumerable<SyndicationItem> GetItemsFromRss(string rss)
        {
            try
            {
                XmlReader reader = XmlReader.Create(rss);
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
