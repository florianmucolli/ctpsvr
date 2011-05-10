using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Citport.json;
using Newtonsoft.Json.Linq;
using Citiport.Cache;
using System.Web;

namespace Citiport.Net.Flickr
{
    public class FlickrPhoto : JsonObject
    {
        public String Id
        {
            set{attributeSet("id", value);}
            get{ return attribteGet("id");}
        }
        public String Title {
            get { return attribteGet("titile"); }
            set { attributeSet("title", value); }

        }
        public String Url {
            get { return attribteGet("url"); }
            set { attributeSet("url", value); }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.WriteJson(sb);
            return sb.ToString();
        }

        private String attribteGet(string key)
        {
            foreach (nvpair nvp in this.NameValuePair)
            {
                if (nvp.Name == key)
                {
                    //StringBuilder sb = new StringBuilder();
                    //nvp.WriteJson(sb);
                    //return sb.ToString();
                    return nvp.Value.ToString();
                }
            }
            return null;
        }

        private void attributeSet(string key, string value)
        {
            bool found = false;
            foreach (nvpair nvp in this.NameValuePair)
            {
                if (nvp.Name == key)
                {
                    nvp.Value = value;
                    found = true;
                }
            }
            if (!found)
            {
                this.NameValuePair.Add(new nvpair() { Name = key, Value = value });
            }
        }
    }

    public class FlickrParser
    {

        // refer: http://www.flickr.com/services/api/misc.urls.html
        // http://farm{farm-id}.static.flickr.com/{server-id}/{id}_{secret}_[mstzb].jpg
        const string PHOTO_SOURCE_URL = "http://farm{0}.static.flickr.com/{1}/{2}_{3}{4}.jpg";

        public static List<FlickrPhoto> Parser(String json, String p_size)
        {
            List<FlickrPhoto> result = new List<FlickrPhoto>();
            JObject o = JObject.Parse(json);
            if (o != null)
            {
                if ((String)o["stat"] == "ok")
                {
                    JObject photos = (JObject)o["photos"];
                    if (photos != null)
                    {
                        JArray photo = (JArray)photos["photo"];
                        if (photo != null)
                        {
                            for (int i = 0; i < photo.Count; i++ )
                            {
                                JObject _p = (JObject)photo[i];
                                if (_p != null)
                                {
                                    FlickrPhoto fphoto = new FlickrPhoto();
                                    fphoto.Id = (String)_p["id"];
                                    fphoto.Title = (HttpUtility.UrlEncode((String)_p["title"]));
                                    string url = String.Format(PHOTO_SOURCE_URL,
                                        (int)_p["farm"],
                                        (String)_p["server"],
                                        (String)_p["id"],
                                        (String)_p["secret"],
                                        (p_size =="")?p_size:"_"+p_size);
                                    fphoto.Url = url;
                                    result.Add(fphoto);
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
    }

    public class FlickrFetcher
    {
        const string API_KEY = "124dbd531584fe33f3b164815e190c70";

        const string API_SECRECT = "6913e6bf09b73624";

        //refer: http://www.flickr.com/services/api/explore/?method=flickr.photos.search;
        const string REQUEST_URL = "http://api.flickr.com/services/rest/?method=flickr.photos.search&api_key={0}&tags={1}&sort={2}&format=json&nojsoncallback=1";
        const string GROUP_REQUEST_URL = "http://api.flickr.com/services/rest/?method=flickr.groups.pools.getPhotos&api_key={0}&group_id={1}&format=json&nojsoncallback=1";

        public List<FlickrPhoto> Fetch(String key, String ordby)
        {
            return this.Fetch(key, ordby, "m");
        }

        public List<FlickrPhoto> Fetch(String key, String ordby, String size)
        {
            String url = String.Format(REQUEST_URL,
               API_KEY, key, ordby);
            return _fetch(url, size);
        }

        public List<FlickrPhoto> FetchGroup(String groupid, String size)
        {
            String url = String.Format(GROUP_REQUEST_URL,
                API_KEY, groupid);
            return _fetch(url, size);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="ordby">date-posted-asc, date-posted-desc, date-taken-asc, date-taken-desc, interestingness-desc, interestingness-asc, and relevance</param>
        /// <param name="size"></param>
        private List<FlickrPhoto> _fetch(String url, String size)
        {
            HttpWebResponse response = null;
           

            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

                // Get response  
                using (response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream  
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    // Console application output  
                    String result = reader.ReadToEnd();
                    List<FlickrPhoto> _r = FlickrParser.Parser(result, size);
                    return _r;
                }
            }
            catch (WebException wex)
            {
                // This exception will be raised if the server didn't return 200 - OK  
                // Try to retrieve more information about the network error  
                if (wex.Response != null)
                {
                    using (HttpWebResponse errorResponse = (HttpWebResponse)wex.Response)
                    {
                        throw wex;
                    }
                }
            }
            finally
            {
                if (response != null) { response.Close(); }
            }
            return new List<FlickrPhoto>();
        }
    }
}
