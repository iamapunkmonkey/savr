using System.Drawing;
using System.Drawing.Imaging;

namespace savr.Lib
{
    public class WebsiteThumbnailGenerator
    {
        public static Bitmap GetWebsiteThumbnail(string Url, int BrowserWidth, int BrowserHeight, int ThumbnailWidth,
            int ThumbnailHeight)
        {
            var thumbnail = new WebsiteThumbnail(Url, BrowserWidth, BrowserHeight, ThumbnailWidth, ThumbnailHeight);
            return thumbnail.GenerateWebsiteThumbnail();
        }
    }
}