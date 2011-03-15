using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Collections;
using HtmlAgilityPack;

/// <summary>
/// Summary description for HtmlUtil
/// </summary>
/// TODO: NOUSER NOW
public class HtmlUtil
{
	public HtmlUtil(){}

    public static Hashtable texToFix = new Hashtable();

    static HtmlUtil()
    {
        texToFix["0026#39;"] = "'";
        texToFix["0026quot;"] = @"""";
        texToFix["003d"] = "=";
    }

    public static String FixGoogleUrlEncode(String text)
    {
        if (text == null)
            return null;
        foreach(Object k in texToFix.Keys)
        {
            String key = Citiport.Util.DataUtil.ObjetToString(k);
            text = text.Replace(key, Citiport.Util.DataUtil.ObjetToString(texToFix[key]));
        }
        return text;
    }

    public static String ParseHtmlParagramOnlyTrimHref(String html)
    {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);
        HtmlNodeCollection p = doc.DocumentNode.SelectNodes(".//p");
        StringBuilder sb = new StringBuilder();
        foreach (HtmlNode n in p)
        {
            HtmlNodeCollection c = n.SelectNodes(".//a");
            if (c != null)
            {
                foreach (HtmlNode n1 in c)
                {
                    if(n1!=null)
                        n1.Attributes.Remove("href");
                }
            }
            sb.Append(n.WriteTo());
        }
        return sb.ToString();
    }

    public static String PurgeHtmlToText(String htm)
    {
        HtmlAgilityPack.Html2Text.HtmlToText tt = new HtmlAgilityPack.Html2Text.HtmlToText();
        return tt.ConvertHtml(htm);
    }
}
