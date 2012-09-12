using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Evential
{
    public partial class ExhibitorCookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Guid g = Guid.NewGuid();

            //need code here to get the entrance person to enter in the Exhibitor ID to issue his cookie. 
            string ExhibitorID = Request.QueryString["Exhibitor"];

            if (string.IsNullOrEmpty(ExhibitorID))
            {
                Label1.Text = "Enter Exhibitor....";
            }
            else
            {

                //check of we have a valid cookie already....
                if (Request.Cookies["ExhibitorCookie"] == null)
                {
                    HttpCookie myCookie = new HttpCookie("ExhibitorCookie");

                    myCookie.Values["GUID"] = g.ToString();
                    myCookie.Expires = DateTime.Now.AddDays(1);

                    Response.Cookies.Add(myCookie);

                    Label1.Text = "Assigned Cookie: " + g.ToString();

                    CommonFunctions.SendCookietoDB(g.ToString(), ExhibitorID);

                   // CommonFunctions.eventToLogDB("Exhbitor: " + GetIPAddress() + ", " + g.ToString());
                }
                else
                {
                    Label1.Text = "Already has cookie";

                    CommonFunctions.eventToLogDB("Exhibitor: No need for new cookie ("+ ExhibitorID +")");
                }
            }

        }



        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;

            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}