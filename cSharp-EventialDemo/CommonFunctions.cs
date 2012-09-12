using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Evential
{
    public class CommonFunctions
    {
        public static string EventsDBConnection = ConfigurationManager.ConnectionStrings["EventsDemoConnectionString"].ConnectionString;


        public static void eventToLogDB(string message)
        {
            SqlConnection conn = new SqlConnection(CommonFunctions.EventsDBConnection);

            string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string insertString =  @"insert into tblLogs
                                    (LogTime,LogEvent,eventID)
                                 values ('" + strNow + "', '"+ message +"', '1')";

            SqlCommand sqlcmd = new SqlCommand(insertString, conn);

            try
            {
                conn.Open();

                sqlcmd.ExecuteNonQuery();
            }
            catch
            {
                //log to event log if sql query fails. 
            }
            finally
            {
                conn.Close();
            }
        }

        public static void SendCookietoDB(string strGUID, string ExhibitorID)
        {
            SqlConnection conn = new SqlConnection(CommonFunctions.EventsDBConnection);


            string insertString = @"UPDATE tblExhibitors SET ExhibitorCookie='" + strGUID +"' Where ExhibitorID='" + ExhibitorID + "'";

            SqlCommand sqlcmd = new SqlCommand(insertString, conn);

            try
            {
                conn.Open();

                sqlcmd.ExecuteNonQuery();
                //return (ExhibitorGUID);

                eventToLogDB ("Exhibitor: " + GetExhibitorNamebyID(ExhibitorID) + " got new Cookie");

            }
            catch
            {
                //log to event log if sql query fails.

            }
            finally
            {
                conn.Close();
            }
 
        }

        public static string GetExhibitorNamebyGUID(string ExhibitorGUID)
        {

            SqlConnection conn = new SqlConnection(CommonFunctions.EventsDBConnection);

           
            string insertString = @"select ExhibitorName from tblExhibitors where ExhibitorCookie = '" + ExhibitorGUID + "'";

            SqlCommand sqlcmd = new SqlCommand(insertString, conn);

            try
            {
                conn.Open();

                return (sqlcmd.ExecuteScalar().ToString());
                //return (ExhibitorGUID);

            }
            catch
            {
                //log to event log if sql query fails.
                return ("No name for Exhibitor");
            }
            finally
            {
                conn.Close();
            }

            
        }

        public static string GetExhibitorNamebyID(string ExhibitorID)
        {

            SqlConnection conn = new SqlConnection(CommonFunctions.EventsDBConnection);


            string insertString = @"select ExhibitorName from tblExhibitors where ExhibitorID = '" + ExhibitorID + "'";

            SqlCommand sqlcmd = new SqlCommand(insertString, conn);

            try
            {
                conn.Open();

                return (sqlcmd.ExecuteScalar().ToString());
                //return (ExhibitorGUID);

            }
            catch
            {
                //log to event log if sql query fails.
                return ("No name for Exhibitor");
            }
            finally
            {
                conn.Close();
            }


        }



        public static string GetAttendeeName(string AttendeeID)
        {
            SqlConnection conn = new SqlConnection(CommonFunctions.EventsDBConnection);


            string insertString = @"select name from tblAttendees where attendeeID = '" + AttendeeID + "'";

            SqlCommand sqlcmd = new SqlCommand(insertString, conn);

            try
            {
                conn.Open();

                return (sqlcmd.ExecuteScalar().ToString());
                //return (ExhibitorGUID);

            }
            catch
            {
                //log to event log if sql query fails.
                return ("No name for Attendee");
            }
            finally
            {
                conn.Close();
            }
        }

        public static string GetAttendeeEmail(string AttendeeID)
        {
            return "AttendeeEmail";
        }


    }
}