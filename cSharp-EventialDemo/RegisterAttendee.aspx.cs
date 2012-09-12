using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Evential
{
    public partial class RegisterAttendee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //first get the cookie on the incoming request.
            HttpCookie myCookie = new HttpCookie("ExhibitorCookie");
            myCookie = Request.Cookies["ExhibitorCookie"];

            string GUID = myCookie.Value.ToString().Replace("GUID=", "");

            // Read the cookie information and display it.
            if (myCookie != null)
            {//Response.Write ("<p>" + GUID + "</p><p>" + myCookie.Value.ToString() + "</p>");
            }
            else
            {
                Label1.Text = "not found";
            }
            //second get the attendeeID from the URL.
            string AttendeeID = Request.QueryString["Attendee"];
            string MessageToScreen = CommonFunctions.GetExhibitorNamebyGUID(GUID) + " has been visited by " + CommonFunctions.GetAttendeeName(AttendeeID);
            if (string.IsNullOrEmpty(AttendeeID))
            {
                Label1.Text = "No Attendee....";
            }
            else
            {
                Label1.Text = MessageToScreen;
            }

            //third, grab name of exhibitor from db using cookie

            //optional, grab attendees name out of the database. 

            //log it to tblLog, exhibitor and name of attendee. 
            CommonFunctions.eventToLogDB(MessageToScreen);

        }
    }
}