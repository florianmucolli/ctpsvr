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
            fetcher.OnReceived += new FlickrFetcher.OnReceivedDataDelegate(fetched);
            fetcher.Fetch("taipei", "interestingness-desc");
            context.Response.ContentType = "application/json";
        }

        protected void fetched(List<JsonObject> result)
        {
            AjaxResponse response = new AjaxResponse();
            response.Status = "OK";
            response.RawData = result;
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