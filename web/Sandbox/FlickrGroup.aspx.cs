using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Citiport.Cache;
using CtpSvr.Code;
using Citiport.Net.Flickr;
using Citport.json;

namespace CtpSvr.Sandbox
{
    public partial class FlickrGroup : System.Web.UI.Page
    {
        ICacheManager cache = null;

        String currentCacheKey = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            String key = Request["key"];

            String orderby = "interestingness-desc";

            if (String.IsNullOrEmpty(key))
                return;

            cache = CacheFactory.GetCache();

            currentCacheKey = key + orderby;

            object result = cache.get(currentCacheKey);

            if (result == null)
            {
                FlickrFetcher fetcher = new FlickrFetcher();
                fetched(fetcher.FetchGroup(key, ""));
            }
            else
            {
                AjaxResponse response = new AjaxResponse();
                response.Status = "OK";
                response.RawData = result;
                Response.Write(response.ToString());
            }
            Response.ContentType = "application/json";
        }

        protected void fetched(List<FlickrPhoto> result)
        {
            List<JsonObject> _r = result.Select(x => (JsonObject)x).ToList<JsonObject>();
            AjaxResponse response = new AjaxResponse();
            response.Status = "OK";
            response.RawData = _r;
            if (cache != null)
                cache.put(_r, currentCacheKey);
            Response.Write(response.ToString());
        }
    }
}