using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Citport.json;
using Citiport.Util.Wikipedia;

namespace CtpSvr
{
    /// <summary>
    /// Summary description for CtpWikiProxy
    /// </summary>
    public class CtpWikiProxy : IHttpHandler
    {

        private HttpContext _context;

        public void ProcessRequest(HttpContext context)
        {
            this._context = context;
            String key = this._context.Request["key"];

            if (String.IsNullOrEmpty(key))
                return;

            context.Response.ContentType = "application/json";
            AjaxResponse response = new AjaxResponse();
            response.Status = "OK";
            WikiArticle article = WikiArticleFactory.CreateWikiArticle(key, "zh");
            response.RawData = Wikipedia.filterContentFirstPara(article.GetHtmlParagramOnlyTrimHref());
            //response.RawData = "<br/><br/>Taipei City (traditional Chinese: 臺北市; simplified Chinese: 台北市; pinyin: Táiběi Shì; literally \"Northern Taiwan City\")[1] is the capital of the Republic of China (commonly known as \"Taiwan\") and the core city of the largest metropolitan area of Taiwan. Situated at the tip of the island, Taipei is located on the Danshui River, and is about 25 km southwest of Keelung, its port on the Pacific Ocean. Another coastal city, Danshui, is about 20 km northwest at the river\'s mouth on the Taiwan Strait. It lies in the two relatively narrow valleys of the Keelung (基隆河) and Xindian (新店溪) rivers, which join to form the Danshui River along the city\'s western border.[2] The city proper (Taipei City) is home to an estimated 2,606,151 people.[3] Taipei, New Taipei, and Keelung together form the Taipei metropolitan area with a population of 6,776,264.[4] However, they are administered under different local governing bodies. \"Taipei\" sometimes refers to the whole metropolitan area, while \"Taipei City\" refers to the city proper.";
            response.RawData = context.Server.UrlEncode(Citiport.Util.DataUtil.RemoveHtmlTagFromString(response.RawData.ToString()));
            context.Response.Write(response.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}