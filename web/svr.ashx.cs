using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Citport.json;
using Citiport.Place;

namespace CtpSvr
{
    /// <summary>
    /// Summary description for svr
    /// </summary>
    public class svr : IHttpHandler
    {
        HttpContext _context = null;

        public void ProcessRequest(HttpContext context)
        {
            this._context = context;

            string key = getKey();
            string method = getMethod();

            if (String.IsNullOrEmpty(key) || String.IsNullOrEmpty(method))
            {
                AjaxResponse response = new AjaxResponse();
                response.Status = "BAD";
                response.Msg = "method and keyword are both required";
                _context.Response.Write(response.ToString());
                _context.Response.ContentType = "application/json";
                return;
            }

            if (method == "ftile")
            {
                string path = "Sandbox/FlickrTiled.aspx?key="+key;
                _context.Server.Transfer(path);
            }
            else if (method == "wiki")
            {
                string encoding = _context.Request["encoding"];
                string path = "CtpWikiProxy.ashx?key="+key;
                if (!String.IsNullOrEmpty(encoding))
                    path += "&encoding=" + encoding;
                _context.Response.Redirect(path);
            }
            else if (method == "flickr")
            {
                string path = "CtpFlickrProxy.ashx?key=" + key;
                _context.Response.Redirect(path);
            }
            else if (method == "flickrfirst")
            {
                string path = "Sandbox/FlickrFirst.aspx?key=" + key;
                _context.Server.Transfer(path);
            }
            else if (method == "flickrgroup")
            {
                string path = "Sandbox/FlickrGroup.aspx?key=900369@N21";
                _context.Server.Transfer(path);
            }
            else if (method == "geocode")
            {
                string path = "Sandbox/geocoding.aspx?key=" + key;
                _context.Server.Transfer(path);
            }
            else if (method == "places")
            {
                string[] ss = new string[]{};
                if (key.Contains(','))
                    ss = key.Split(',');
                else
                {
                    if (key.ToLower() == "beijing" || key == "北京")
                        ss = new string[] { PlacesFakeData.BeijingLat + "", "0.0" };
                    else
                        ss = new string[] { PlacesFakeData.TaipeiLat + "", "0.0" };
                }

                string path = "Sandbox/TestPlacesFetcher.aspx?lat=" + ss[0] + "&lng=" + ss[1];
                _context.Server.Transfer(path);
            }
            else
            {
                AjaxResponse response = new AjaxResponse();
                response.Status = "BAD";
                response.Msg = "unknown method or keyword";
                _context.Response.Write(response.ToString());
                _context.Response.ContentType = "application/json";
            }
        }

        private String getMethod()
        {
            return _context.Request["method"];
        }

        private String getKey()
        {
            return _context.Request["key"];
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