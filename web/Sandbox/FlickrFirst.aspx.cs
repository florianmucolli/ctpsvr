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

        private void CityImageException(String cityname)
        {
            if (cityname == "台北")
            {
                Response.Redirect("sandbox\\cityimg\\c5.png");
                //Bitmap img = new Bitmap(Server.MapPath("cityimg\\c5.png"));
                //return Citiport.Util.DataUtil.ImageToBase64(img, ImageFormat.Png);
            }
            else if (cityname == "北京")
            {
                Response.Redirect("sandbox\\cityimg\\c4.png");
                //Bitmap img = new Bitmap(Server.MapPath("cityimg\\c4.png"));
                //return Citiport.Util.DataUtil.ImageToBase64(img, ImageFormat.Png);
            }
            else if (cityname == "上海")
            {
                Response.Redirect("sandbox\\cityimg\\c3.png");
                //Bitmap img = new Bitmap(Server.MapPath("cityimg\\c3.png"));
                //return Citiport.Util.DataUtil.ImageToBase64(img, ImageFormat.Png);
            }
            else if (cityname == "舊金山")
            {
                Response.Redirect("sandbox\\cityimg\\c2.png");
                //Bitmap img = new Bitmap(Server.MapPath("cityimg\\c2.png"));
                //return Citiport.Util.DataUtil.ImageToBase64(img, ImageFormat.Png);
            }
            else if (cityname == "香港")
            {
                Response.Redirect("sandbox\\cityimg\\c1.png");
                //Bitmap img = new Bitmap(Server.MapPath("cityimg\\c1.png"));
                //return Citiport.Util.DataUtil.ImageToBase64(img, ImageFormat.Png);
            }
        }

        protected void fetch()
        {
            String key = Request["key"];
            PhotosSearch photosearch = new PhotosSearch();
            CityImageException(key);
            String base64 = photosearch.GetFirst(key, "relevance", "m");
            Bitmap bmp = (Bitmap)Citiport.Util.DataUtil.Base64ToImage(base64);
            Response.Clear();
            Response.ContentType = "image/jpeg";
            bmp.Save(Response.OutputStream, ImageFormat.Jpeg);
        }
    }
}