using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Web;

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

    public class FakePlacesFetcherImpl : IPlacesFetcher
    {
        public String getTypeByTitie(String title)
        {
            if (String.IsNullOrEmpty(title))
                return "none";
            else
            {
                if ((new String[]{"胡同儿","江湖酒吧","Hao Yun Yue Qi","参差咖啡馆",
                    "No.56 Private Kitchens","E.A.T Cafe"}).Contains(title))
                {
                    return "local";
                }
                else if ((new String[]{"HotCandy烤棉花糖","大車輪火車壽司","西門新宿","天仁茗茶","蛋蛋屋",
                    "成都楊桃冰","真善美森林1店"}).Contains(title))
                {
                    return "might";
                }
                else if ((new String[]{"星聚點KTV時尚宴","玉林雞腿大王","天天利美食坊","港記酥皇店","天外天精緻麻辣火鍋",
                "生活工場Living plus"}).Contains(title))
                {
                    return "new";
                }
                else
                    return "none";
            }
        }

        public List<PlaceObj> fetch(double lat, double lng)
        {
            string json = PlacesFakeData.Taipei;
            if (lat == PlacesFakeData.BeijingLat)
                json = PlacesFakeData.Beijing;

            List<PlaceObj> objs = new List<PlaceObj>();
            JArray data = JArray.Parse(json);
            if (data != null)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    JObject _p = (JObject)data[i];
                    objs.Add(new PlaceObj()
                    {
                        Title = HttpUtility.UrlEncode((String)_p["title"], Encoding.UTF8),
                        Address =  HttpUtility.UrlEncode((String)_p["address"], Encoding.UTF8),
                        Phone = (String)_p["phone"],
                        ImageUrl = (String)_p["imageurl"],
                        Latitude = (String)_p["latitude"],
                        Longtitude = (String)_p["longtitude"],
                        Type = getTypeByTitie((String)_p["title"])
                    });
                }
            }
            return objs;
        }
    }
}
