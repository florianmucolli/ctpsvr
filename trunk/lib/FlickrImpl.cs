using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Citiport.Net.Flickr;
using System.Web;
using Citiport.Network;
using Citiport.Cache;

namespace Citiport.Photo.Flickr
{
    public class PhotosSearch
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

        public PhotosSearch()
        {
            this.fetcher = new FlickrPhotoFetcher();
        }

        public String GetFirst(String tags, String orderby, String size)
        {
            FlickrFetcher urlsfetcher = new FlickrFetcher();
            //75x75 filckr s for tiles
            List<FlickrPhoto> result = urlsfetcher.Fetch(HttpUtility.UrlEncode(tags), orderby, size);
            List<String> urls = new List<String>() { result[5].Url };
            List<Image> image = fetcher.fetch(urls);
            String base64 = Citiport.Util.DataUtil.ImageToBase64(image[0], System.Drawing.Imaging.ImageFormat.Jpeg);
            return base64;
        }
    }
}
