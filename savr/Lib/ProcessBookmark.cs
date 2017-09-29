using System;
using System.Net;
using System.Text.RegularExpressions;
using savr.Contexts;
using savr.Models;

namespace savr.Lib
{
    public class ProcessBookmark
    {
        private static DataContext Context { get; set; } = new DataContext();

        public static Guid NewBookmark(string url)
        {
            var id = Guid.NewGuid();

            var bookmark = new Bookmark
            {
                Id = id,
                Title = ProcessTitle(url),
                Url = url
            };
            
            Context.Bookmarks.Add(bookmark);

            Context.SaveChanges();
            
            return id;
        }

        public static string ProcessTitle(string url)
        {
            try
            {
                var wc = new WebClient();
                var html = wc.DownloadString(url);
                var x = new Regex("<title>(.*)</title>");
                var m = x.Matches(html);

                return m.Count > 0 ? m[0].Value.Replace("<title>", "").Replace("</title>", "") : "";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }
    }
}