using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Citiport.Net.Flickr;
using Citport.json;
using System.Text;
using Citiport.Cache;
using CtpSvr.Code;

namespace CtpSvr
{
    /// <summary>
    /// Summary description for CtpFlickrProxy
    /// </summary>
    public class CtpFlickrProxy : IHttpHandler
    {

        HttpContext _context = null;

        ICacheManager cache = null;

        String currentCacheKey = "";

        public void ProcessRequest(HttpContext context)
        {
            this._context = context;

            String key = this._context.Request["key"];

            String orderby = "interestingness-desc";

            if (String.IsNullOrEmpty(key))
                return;

            cache = CacheFactory.GetCache();

            currentCacheKey = key + orderby;

            object result = cache.get(currentCacheKey);

            if (result == null)
            {
                FlickrFetcher fetcher = new FlickrFetcher();
                fetched(fetcher.Fetch(key, orderby));
            }
            else
            {
                AjaxResponse response = new AjaxResponse();
                response.Status = "OK";
                response.RawData = result;
                _context.Response.Write(response.ToString());
            }
            context.Response.ContentType = "application/json";
        }

        protected void fetched(List<FlickrPhoto> result)
        {
            List<JsonObject> _r = result.Select(x => (JsonObject)x).ToList<JsonObject>();
            AjaxResponse response = new AjaxResponse();
            response.Status = "OK";
            response.RawData = _r;
            if (cache != null)
                cache.put(_r, currentCacheKey);
            _context.Response.Write(response.ToString());
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