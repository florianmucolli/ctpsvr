using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Citiport.Net.Flickr;
using Citport.json;
using Citiport.Photo;
using System.Drawing;
using System.Drawing.Imaging;
using Citiport.Network;
using Citiport.Cache;
using CtpSvr.Code;

namespace CtpSvr.Sandbox
{
    public partial class FlickrTiled : System.Web.UI.Page
    {
        private ICacheManager cache = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fetch();
            }
        }

        protected void fetch()
        {
            String key = Request["key"];
            if (String.IsNullOrEmpty(key))
                return;

            FlickrImageTiler tiler = new FlickrImageTiler();
            tiler.CacheManager = CacheFactory.GetCache();
            Bitmap bmp = (Bitmap)tiler.tiler(key, 5, 30, "relevance");
            //String filepath = MapPath("/Sandbox/tmp/tiled.jpg");
            //bmp.Save(filepath);
            Response.ContentType = "image/jpeg";
            bmp.Save(Response.OutputStream, ImageFormat.Jpeg);
        }

    }
}