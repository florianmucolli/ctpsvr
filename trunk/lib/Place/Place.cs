using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Citport.json;

namespace Citiport.Place
{
    public class PlaceObj : JsonObject
    {
        public String Id
        {
            set { attributeSet("id", value); }
            get { return attribteGet("id"); }
        }
        public String Title
        {
            get { return attribteGet("titile"); }
            set { attributeSet("title", value); }
        }

        public String Type
        {
            get { return attribteGet("type"); }
            set { attributeSet("type", value); }
        }

        public String Phone
        {
            get { return attribteGet("phone"); }
            set { attributeSet("phone", value); }
        }

        public String ImageUrl
        {
            get { return attribteGet("imageurl"); }
            set { attributeSet("imageurl", value); }
        }

        public String Address
        {
            get { return attribteGet("address"); }
            set { attributeSet("address", value); }
        }

        public String Subtitle
        {
            get { return attribteGet("subtitle"); }
            set { attributeSet("subtitle", value); }
        }

        public String Latitude
        {
            get { return attribteGet("latitude"); }
            set { attributeSet("latitude", value); }
        }

        public String Longtitude
        {
            get { return attribteGet("longtitude"); }
            set { attributeSet("longtitude", value); }
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
}
