using System.Drawing;
using System.Threading;

namespace savr.Lib
{
    public class WebsiteThumbnail
    {
        private Bitmap _bitmap;

        public WebsiteThumbnail(string url, int browserWidth, int browserHeight, int thumbnailWidth, int thumbnailHeight)
        {
            Url = url;
            BrowserWidth = browserWidth;
            BrowserHeight = browserHeight;
            ThumbnailHeight = thumbnailWidth;
            ThumbnailWidth = thumbnailHeight;
        }

        public int ThumbnailWidth { get; set; }
        public int ThumbnailHeight { get; set; }
        public int BrowserHeight { get; set; }
        public int BrowserWidth { get; set; }
        public string Url { get; set; }

        public Bitmap GenerateWebsiteThumbnail()
        {
            var thread = new Thread(new ThreadStart(_GenerateWebsiteThumbnail));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join(0);
            return _bitmap;
        }

        private void _GenerateWebsiteThumbnail()
        {
             
        }
    }
}