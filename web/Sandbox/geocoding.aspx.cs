using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CtpGglGeo.Core;
using CtpGglGeo.Ggl;
using CtpGglGeo.Const;
using Citport.json;

namespace CtpSvr.Sandbox
{
    public partial class geocoding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fetch();
        }

        private void fetch()
        {
            Response.Clear();
            SpotInfo sinfo = new SpotInfo();

            String key = Request["key"];

            sinfo.Address = key;
            Geocoder geo = new Geocoder();
            GeoResult result = geo.GetGeoResult(sinfo);
            JsonObject jobj = new JsonObject();
            if (GeoResultStatus.OK.Equals(result.Status))//@since 0.1.1
            {
                jobj.NameValuePair.Add(new JsonObject.nvpair()
                {Name="lat", Value = result.Results[0].Geometry.Location.Lat});
                jobj.NameValuePair.Add(new JsonObject.nvpair() 
                {Name = "lng", Value = result.Results[0].Geometry.Location.Lng });
            }
            AjaxResponse jresponse = new AjaxResponse();
            jresponse.Status = "OK";
            jresponse.RawData = jobj;
            jresponse.Msg = "lat, lng of " + key;
            Response.Write(jresponse.ToString());
            Response.ContentType = "application/json";
        }
    }
}