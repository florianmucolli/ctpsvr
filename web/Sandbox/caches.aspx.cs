using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;

public partial class Sandbox_list_caches : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        IDictionaryEnumerator ie = Cache.GetEnumerator();
        while(ie.MoveNext())
        {
            sb.Append("<br/>");
            sb.Append(String.Format("<span>Key</span>: {0} <span>Value</span>: {1}<br/> ", ie.Key, ie.Value.ToString()));
        }
        Response.Write(sb.ToString());
    }
}
