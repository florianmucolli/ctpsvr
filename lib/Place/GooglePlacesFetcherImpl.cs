using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Citiport.Place;
using System.Web;

namespace Citiport.Place
{
    public class GooglePlacesFetcherImpl : IPlacesFetcher
    {
        public int Radius = 500;

        class ConsoleLogger : CtpGglPlaces.Interface.ILogger
        {
            public void debug(string log)
            {
                Console.WriteLine("url:" + log);
            }
        }

        public List<PlaceObj> fetch(double lat, double lng)
        {
            CtpGglPlaces.Core.SearchUrlParameter param = new CtpGglPlaces.Core.SearchUrlParameter();
            param.KeyProvider = new CtpGgl.API.GoogleAPIKeysProvider();
            param.Location = new CtpGglPlaces.Impl.GeoPointImpl(lat, lng);
            param.Radius = 500;
            param.Sensor = false;
            param.Logger = new ConsoleLogger();

            List<PlaceObj> result = new List<PlaceObj>();
            CtpGglPlaces.Impl.PlacesResult presult = CtpGglPlaces.Searcher.GetPlaces(param, "json");
            if (presult.Status == "OK")
            {
                List<String> s = new List<string>();
                foreach (CtpGglPlaces.Impl.PlaceObj obj in presult.Results)
                {
                    result.Add(new PlaceObj()
                    {
                        Title = HttpUtility.UrlEncode(obj.Name, Encoding.UTF8),
                        Address = HttpUtility.UrlEncode("", Encoding.UTF8),
                        Phone = "",
                        ImageUrl = "",
                        Latitude = obj.Geometry.Location.Lat + "",
                        Longtitude = obj.Geometry.Location.Lng +"",
                        Type = ""
                    });
                }
            }
            return result;
        }
    }
}
