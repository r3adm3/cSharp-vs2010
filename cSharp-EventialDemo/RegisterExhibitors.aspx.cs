using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Evential
{
    public partial class RegisterExhibitors : System.Web.UI.Page
    {
 
        protected void Page_Load(object sender, EventArgs e)
        {
            string ExhibitorID = Request.QueryString["Exhibitor"];
            Guid g = Guid.NewGuid();

            if (string.IsNullOrEmpty(ExhibitorID))
            {
                lblExhibitor.Text = "No Exhibitor....";
            }
            else
            {
                //test that he exists in the db.
                if (blnExhibitorExists(ExhibitorID))
                {
                    lblExhibitor.Text = "Welcome " + ExhibitorID + ", Please Get Exhibitor to scan this code to set them up on this system...";
                    lblQRCode.Text = @"<img src='http://chart.googleapis.com/chart?chs=300x300&cht=qr&chl=http://evential.no-ip.org/ExhibitorCookie.aspx?Exhibitor=" + ExhibitorID + "' />";

                    /* **START HERE, not sure I need this cookie assigment bit here (it is copied 
                    // from exhibitorcookie.aspx. It'd mean an Exhibitor could scan his own code in before the event)

                    if (Request.Cookies["ExhibitorCookie"] == null)
                    {
                        HttpCookie myCookie = new HttpCookie("ExhibitorCookie");

                        myCookie.Values["GUID"] = g.ToString();
                        myCookie.Expires = DateTime.Now.AddDays(1);

                        Response.Cookies.Add(myCookie);

                        lblExhibitor.Text = "Assigned Cookie: " + g.ToString();

                        CommonFunctions.SendCookietoDB(g.ToString(), ExhibitorID);

                        // CommonFunctions.eventToLogDB("Exhbitor: " + GetIPAddress() + ", " + g.ToString());
                    }
                    else
                    {
                        lblExhibitor.Text = "Already has cookie";

                        CommonFunctions.eventToLogDB("Exhibitor: No need for new cookie (" + ExhibitorID + ")");
                    }
                    // **END HERE. */

                    CommonFunctions.eventToLogDB("Exhibitor " + ExhibitorID + " logged in at Registration");
                    
                }
                else
                {
                    lblExhibitor.Text = "Not Registered as an Exhibitor (ID: " + ExhibitorID + ")" ;

                    CommonFunctions.eventToLogDB("Unregistered Exhibitor attempt (ID: " + ExhibitorID + ")");
                }

            }

        }


        
        private static bool blnExhibitorExists(string ExhibitorID)
        {
            int count = 0;
 
            SqlConnection conn = new SqlConnection (CommonFunctions.EventsDBConnection); 

            SqlCommand sqlcmd = new SqlCommand("Select count(*) from tblExhibitors where ExhibitorID='" + ExhibitorID + "'", conn);

        

            try
            {
                conn.Open();

                count = Convert.ToInt32(sqlcmd.ExecuteScalar());

                //CommonFunctions.eventToLogDB(count.ToString());
            }
            catch
            {
                CommonFunctions.eventToLogDB("I'm in the catch in blnExhibitorExists");
                //we're in error condition here....push it there.
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

    }

   
}