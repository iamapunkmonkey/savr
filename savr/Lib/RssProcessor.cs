using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using savr.Models;

namespace savr.Lib
{
    public class RssProcessor
    {
        public static IEnumerable<RssItem> processFeed(string RssURL)
        {
            var wclient = new WebClient();
            var rssData = wclient.DownloadString(RssURL);

            var xml = XDocument.Parse(rssData);
            var rssFeedData = from x in xml.Descendants("item")
                select new RssItem
                {
                    Title = (string) x.Element("title"),
                    Link = (string) x.Element("link"),
                    Description = (string) x.Element("description"),
                    PubDate = (DateTime) x.Element("pubDate")
                };

            return rssFeedData;
        }
    }
}