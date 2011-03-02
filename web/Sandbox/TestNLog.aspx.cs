using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NLog;


namespace CtpSvr.Sandbox
{
    public partial class TestNLog : System.Web.UI.Page
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected void Page_Load(object sender, EventArgs e)
        {
            logger.Debug("NLog runnin");
        }
    }
}