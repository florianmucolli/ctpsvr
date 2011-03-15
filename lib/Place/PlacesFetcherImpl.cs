using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Citiport.Place
{
    public class DummyPlacesFetcherImpl : IPlacesFetcher
    {
        public int Count { get; set; }

        public List<PlaceObj> fetch(double lat, double lng)
        {
            List<PlaceObj> list = new List<PlaceObj>(Count);
            for (int i = 0; i < this.Count; i++)
            {
                PlaceObj obj = new PlaceObj();
                obj.Title = "Place: " + (i + 1);
                obj.Subtitle = "Description";
                obj.Latitude = lat + ((0.01) * (i + 1)) + "";
                obj.Longtitude = lng + ((0.01) * (i + 1)) + "";
                list.Add(obj);
            }
            return list;
        }
    }
}
