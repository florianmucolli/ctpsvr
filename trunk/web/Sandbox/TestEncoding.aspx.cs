using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace CtpSvr.Sandbox
{
    public partial class TestEncoding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(Server.UrlEncode("上海")+"<br/>");
            Response.Write(Encoding.Default.EncodingName + "<br/>");
            Response.Write(HttpUtility.UrlEncode("上海", Encoding.Default)+"<br/>");
            Response.Write(Encoding.UTF8.EncodingName + "<br/>");
            String afterencode = HttpUtility.UrlEncode("上海", Encoding.UTF8);
            Response.Write(afterencode + "<br/>");
            Response.Write("after decode<br/>");
            Response.Write(HttpUtility.UrlDecode(afterencode, Encoding.UTF8) + "<br/>");
        }
    }
}