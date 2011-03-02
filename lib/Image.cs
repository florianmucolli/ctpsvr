using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Citiport.Network;
using Citiport.Net.Flickr;
using System.Web;
using Citiport.Cache;


namespace Citiport.Photo
{
    public interface IImageTiler
    {
        object tiler(List<object> images, int w, int tileSize);
    }

    public class SimpleImageTiler : IImageTiler
    {
        public object tiler(List<object> images, int w, int tileSize)
        {
            int count = images.Count;
            int _w = tileSize * w;
            int _h = tileSize * ((count /w  + count % w /w));
            Bitmap dst = new Bitmap(_w,_h);
            using (Graphics g = Graphics.FromImage(dst))
            {
                for (int i = 0; i < count; i++)
                {
                    Image tile = (Image)images[i];
                    g.DrawImage(tile, new Point(i % w * tileSize, i / w * tileSize));
                }
            }
            return dst;
        }
    }

    public class FlickrImageTiler : SimpleImageTiler
    {
        private FlickrPhotoFetcher fetcher = null;

        private ICacheManager cacheManager = null;

        public ICacheManager CacheManager
        {
            set
            {
                this.cacheManager = value;
            }
            get
            {
                return this.cacheManager;
            }
        }

        public FlickrImageTiler()
        {
            fetcher = new FlickrPhotoFetcher();
        }

        public object tiler(List<String> imageUrl, int w)
        {
            if (fetcher != null)
            {
                List<Image> images = fetcher.fetch(imageUrl);
                int size = 75; //flickr s
                return this.tiler(images.Select(x=>(object)x).ToList<object>(), w, size);
            }
            return null;
        }

        public Bitmap tiler(string keyword, int w, int count, String orderby)
        {
            String base64 = null;
            if (this.cacheManager != null)
            {
                base64 = (String)this.cacheManager.get(keyword);
            }
            if (string.IsNullOrEmpty(base64))
            {
                base64 = tilerInternalToBase64Jpeg(keyword, w, count, orderby);
                if(this.cacheManager != null)
                 this.cacheManager.put(base64, keyword);
            } 
            return (Bitmap)DataUtil.Base64ToImage(base64);
        }

        private String tilerInternalToBase64Jpeg(string keyword, int w, int count, String orderby)
        {
            FlickrFetcher fetcher = new FlickrFetcher();
            //75x75 filckr s for tiles
            List<FlickrPhoto> result = fetcher.Fetch(HttpUtility.UrlEncode(keyword), orderby, "s");
            List<String> urls = result.Take(count).Select(x => x.Url).ToList<String>();
            FlickrImageTiler tiler = new FlickrImageTiler();
            Bitmap bmp = (Bitmap)tiler.tiler(urls, 5);
            String base64 = DataUtil.ImageToBase64(bmp, System.Drawing.Imaging.ImageFormat.Jpeg);
            return base64;
        }
    }
}
