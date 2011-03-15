using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Citiport.Place;
using Citport.json;

namespace CtpSvr.Sandbox
{
    public partial class TestPlacesFetcher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fetch();
        }

        protected void fetch()
        {
            String lat = Request["lat"];
            String lng = Request["lng"];

            IPlacesFetcher fetcher = PlacesFetcherFactory.getFetcher(this);
            List<PlaceObj> result = fetcher.fetch(double.Parse(lat), double.Parse(lng));
            List<JsonObject> _r = result.Select(x => (JsonObject)x).ToList<JsonObject>();
            AjaxResponse response = new AjaxResponse();
            response.Status = "OK";
            response.RawData = _r;
            Response.Clear();
            Response.ContentType = "application/json";
            Response.Write(response.ToString());
        }
    }
}