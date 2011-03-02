using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CtpSvr.Sandbox
{
    public partial class TestBase4ImageString : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String filepath = MapPath("/Sandbox/tmp/tiled.jpg");
            System.Drawing.Image bmp = Bitmap.FromFile(filepath);
            String base64 = DataUtil.ImageToBase64(bmp, System.Drawing.Imaging.ImageFormat.Jpeg);
            Response.Write(base64);
            System.Drawing.Image result = DataUtil.Base64ToImage(base64);
            result.Save(MapPath("/Sandbox/tmp/result.jpg"));
            result.Dispose();
        }
    }
}