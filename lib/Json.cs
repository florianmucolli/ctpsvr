using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;

namespace Citport.json
{
    public class AjaxResponse
    {
        public String Status { get; set; }
        public object RawData { get; set; }
        public String Msg { set; get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            JsonObject jo = new JsonObject()
            {
                NameValuePair = new List<JsonObject.nvpair>()
                {
                    new JsonObject.nvpair(){Name="status", Value=Status},
                    new JsonObject.nvpair(){Name="msg", Value=Msg},
                    new JsonObject.nvpair(){Name="data", Value=RawData},
                    new JsonObject.nvpair(){Name="foo", Value="bar"}
                }
            };
            jo.WriteJson(sb);
            return sb.ToString();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class JsonObject
    {

        public List<nvpair> NameValuePair = new List<nvpair>();

        public void WriteJson(StringBuilder output)
        {
            StringBuilder bu = new StringBuilder();
            bu.Append("{");
            for (int i = 0; i < NameValuePair.Count; i++)
            {
                if (i > 0)
                    bu.Append(",");
                NameValuePair[i].WriteJson(bu);
            }
            bu.Append("}");
            output.Append(bu.ToString());
        }

        public class nvpair
        {
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            public String Name { get; set; }
            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>The value.</value>
            public Object Value { get; set; }// List<JsonObject> children = new List<JsonObject>();

            /// <summary>
            /// Writes the json.
            /// </summary>
            /// <param name="output">The output.</param>
            public void WriteJson(StringBuilder output)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(String.Format("\"{0}\"", Name));
                sb.Append(":");
                if (Value == null)
                    sb.Append("\"\"");
                else
                {
                    if (typeof(List<JsonObject>) == Value.GetType())
                    {
                        List<JsonObject> list = (List<JsonObject>)Value;
                        sb.Append("[");
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (i > 0)
                                sb.Append(",");
                            list[i].WriteJson(sb);
                        }
                        sb.Append("]");
                    }
                    else if (typeof(JsonObject) == Value.GetType())
                    {
                        ((JsonObject)Value).WriteJson(sb);
                    }
                    else if (typeof(String) == Value.GetType())
                    {
                        String v = Value.ToString();// DataUtil.ReplaceNewLine(Value.ToString(), "<br/>");
                        //v = v.Replace("'", "\\'");
                        if(Name == "onclick")
                           sb.Append(String.Format("{0}", v));
                        else
                          sb.Append(String.Format("\"{0}\"", v));
                    }
                    else
                    {
                        sb.Append(String.Format("\"{0}\"", Value));
                    }
                }
                output.Append(sb.ToString());
            }
        }
    }
}
