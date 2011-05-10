using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Net;
using System.Xml;
using HtmlAgilityPack;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Wikipedia
/// </summary>
namespace Citiport.Util.Wikipedia
{
    public class WikiArticleFactory
    {
        // If this string occurs in response => no such article in wikipedia
        public const String WIKIPEDIA_ARTICLE_NOT_FOUND= "NO TITLE";//@"<a title=""Special:Search/NO TITLE"" class=""wikiHref"">";

        public const String WIKIPEDIA_ARTICLE_MAY_REFER = "may refer to";

        public static WikiArticle CreateWikiArticle(string title, string lang)
        {
            string t = HttpUtility.UrlEncode(title, Encoding.UTF8);
            t = title;
            string url = string.Format(Wikipedia.GetWikipediaApiUrlByLang(lang), t);
            System.Net.HttpWebRequest webRequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
            //try
            //{
                webRequest.UserAgent = Wikipedia.FIREFOX_USERAGENT;
                System.Net.HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                XmlDocument XMLdoc = new XmlDocument();
                XMLdoc.Load(webResponse.GetResponseStream());
                XmlNodeList xnl = XMLdoc.SelectNodes("api/parse/text");
                string html = xnl[0].InnerText;
                //if not found return empty
                if (!html.Contains(WIKIPEDIA_ARTICLE_NOT_FOUND))
                {
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(html);
                    WikiArticle article = new WikiArticle(title, lang, doc);
                    return article;
                }else
                    return new WikiArticle(title, lang, new HtmlDocument());
            //}
            //catch (Exception exp)
            //{
            //    throw exp;
            //}
        }
    }

    public class WikiArticle
    {
        private String _title;
        private String _lang;
        private HtmlDocument _doc = null;
        public HtmlDocument HtmlDoc { get { return _doc; } }
        public static WikiArticle EmptyArticle = new WikiArticle("", "en", new HtmlDocument());

        public WikiArticle(String title, String lang, HtmlDocument doc)
        {
            _title = title;
            _lang = lang;
            _doc = doc;
        }

        public String GetHtmlParagramOnlyTrimHref()
        {
            if (_doc != null)
            {
                HtmlNodeCollection p = _doc.DocumentNode.SelectNodes(".//p");
                StringBuilder sb = new StringBuilder();
                if (p != null)
                {
                    foreach (HtmlNode n in p)
                    {
                        HtmlNodeCollection c = n.SelectNodes(".//a");
                        if (c != null)
                        {
                            foreach (HtmlNode n1 in c)
                            {
                                if (n1 != null)
                                {
                                    n1.Attributes.Remove("href");
                                    n1.SetAttributeValue("class", "wikiHref");
                                }
                            }
                        }
                        sb.Append(n.WriteTo());
                    }
                    return sb.ToString();
                }
                else
                    return "";
            }
            else
                throw new Exception("HtmlDocument is not loaded");
        }
    }
        

    public class Wikipedia
    {
        public const String FIREFOX_USERAGENT = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.2.3) Gecko/20100401 Mozilla/5.0 (X11; U; Linux i686; it-IT; rv:1.9.0.2) Gecko/2008092313 Ubuntu/9.25 (jaunty) Firefox/3.8";
        public Wikipedia()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static bool isEmptyAricle(String input)
        {
            if (DataUtil.IsEmptyString(input))
                return true;
            if (input.Contains(WikiArticleFactory.WIKIPEDIA_ARTICLE_NOT_FOUND))
                return true;
            if (input.Contains(WikiArticleFactory.WIKIPEDIA_ARTICLE_MAY_REFER))
                return true;
            return false;
        }

        public static String  filterContentForDisplay(String input)
        {
           if(isEmptyAricle(input))
           {
               return string.Empty;
           }
            else
            {
                return input;
            }
        }

        public static String filterContentFirstPara(String input)
        {
            if (isEmptyAricle(input))
            {
                return string.Empty;
            }
            else
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(input);
                HtmlNodeCollection p = doc.DocumentNode.SelectNodes(".//p");
                if (p != null)
                {
                    foreach (HtmlNode n in p)
                    {
                        if (n.InnerHtml != null && !n.InnerHtml.Trim().Equals(String.Empty))
                        {
                            String s = HtmlUtil.PurgeHtmlToText(n.WriteTo());
                            if (!DataUtil.IsEmptyString(s))
                                return s;
                        }
                    }
                }
                return input;
            }
        }

        public const string WIKI_CONTENT_FOR_HOTSPOT_COMMENT = @"[wikipedia.content]";

        [Obsolete("Use WikiArticleFactory.Create..")]
        public static String GetHTMLFromWikipedia(String title, String lang)
        {
            string t = HttpContext.Current.Server.UrlEncode(title);
            string url = string.Format(GetWikipediaApiUrlByLang(lang), t);
            System.Net.HttpWebRequest webRequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
            //faking magic browser
            webRequest.UserAgent = Wikipedia.FIREFOX_USERAGENT;
           // webRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
           // webRequest.Accept = "text/xml";
            System.Net.HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            XmlDocument XMLdoc = new XmlDocument();
            XMLdoc.Load(webResponse.GetResponseStream());
            XmlNodeList xnl = XMLdoc.SelectNodes("api/parse/text");
            string a = xnl[0].InnerText;
            return HttpUtility.HtmlDecode(a);
        }

        public static String GetWikipediaApiUrlByLang(String lang)
        {
            lang = lang.ToLower();
            switch (lang)
            {
                case "en":
                    return "http://en.wikipedia.org/w/api.php?action=parse&format=xml&page={0}";
                case "zh":
                    return "http://zh.wikipedia.org/w/api.php?action=parse&format=xml&page={0}";
                case "zh-tw":
                    return "http://zh.wikipedia.org/w/api.php?action=parse&format=xml&variant=zh-tw&page={0}";
                case "zh-cn":
                    goto case "zh";
                case "zh-hant":
                    goto case "zh-tw";
                default:
                    goto case "en";
            }
        }
    }
}