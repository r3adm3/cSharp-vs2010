using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Evential
{
    public partial class CleanUpCookies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookie = new HttpCookie("ExhibitorCookie");

            myCookie.Expires = DateTime.Now.AddDays(-1d);

            Response.Cookies.Add(myCookie);
        }
    }
}