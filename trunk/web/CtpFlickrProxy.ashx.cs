using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Citiport.Net.Flickr;
using Citport.json;
using System.Text;

namespace CtpSvr
{
    /// <summary>
    /// Summary description for CtpFlickrProxy
    /// </summary>
    public class CtpFlickrProxy : IHttpHandler
    {

        HttpContext _context = null;

        public void ProcessRequest(HttpContext context)
        {
            this._context = context;

            FlickrFetcher fetcher = new FlickrFetcher();
            fetched(fetcher.Fetch("taipei", "interestingness-desc"));
            context.Response.ContentType = "application/json";
        }

        protected void fetched(List<FlickrPhoto> result)
        {
            List<JsonObject> _r = result.Select(x => (JsonObject)x).ToList<JsonObject>();
            AjaxResponse response = new AjaxResponse();
            response.Status = "OK";
            response.RawData = _r;
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