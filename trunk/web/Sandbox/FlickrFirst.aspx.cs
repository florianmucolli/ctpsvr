using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CtpSvr.Code;
using System.Drawing.Imaging;
using Citiport.Photo.Flickr;
using System.Drawing;

namespace CtpSvr.Sandbox
{
    public partial class FlickrFirst : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fetch();
        }

        protected void fetch()
        {
            String key = Request["key"];
            PhotosSearch photosearch = new PhotosSearch();
            String base64 = photosearch.GetFirst(key, "relevance", "m");
            Bitmap bmp = (Bitmap)Citiport.Util.DataUtil.Base64ToImage(base64);
            //String filepath = MapPath("/Sandbox/tmp/tiled.jpg");
            //bmp.Save(filepath);
            Response.Clear();
            Response.ContentType = "image/jpeg";
            bmp.Save(Response.OutputStream, ImageFormat.Jpeg);
        }
    }
}