using System.Collections.Generic;
using NetDevPL.Infrastructure.Helpers;

namespace NetDevPLWeb.Features.WebCasts
{
    public class WebcastsSource
    {
        public List<Webcast> GetWebcastList() => JsonReaderHelper.ReadObjectListFromJson<Webcast>("Features/Webcasts/webcastsList.json");
    }
}