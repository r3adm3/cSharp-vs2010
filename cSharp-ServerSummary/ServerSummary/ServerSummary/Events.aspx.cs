using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogQuery = MSUtil.LogQueryClassClass;
using EventLogInputFormat = MSUtil.COMEventLogInputContextClassClass;
using LogRecordSet = MSUtil.ILogRecordset;
using System.Data;
using LogRecord = MSUtil.ILogRecord;

namespace ServerSummary
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblServerName.Text = System.Environment.MachineName.ToString();
            lblServerName2.Text = System.Environment.MachineName.ToString();

            string strEventLog;
            string strNumberOfEvents;

            if (!Page.IsPostBack)
            {
                strEventLog = "Application";
                strNumberOfEvents = "15";
            }

            strEventLog = ddlEventLog.SelectedItem.Value;
            strNumberOfEvents = ddlNumberOfEvents.SelectedItem.Value;

            Top10Events("APPLICATION");
            Top10Events("SYSTEM");

            try
            {

               // Instantiate the LogQuery object
                LogQuery oLogQuery = new LogQuery();

                // Instantiate the Event Log Input Format object
                EventLogInputFormat oEVTInputFormat = new EventLogInputFormat();

                // Instantiate the data tables, columns and rows....
                DataTable dtData = new DataTable("results");
                DataColumn dtColumn = new DataColumn("timeGenerated");
                dtData.Columns.Add(dtColumn);

                DataColumn dtColumn2 = new DataColumn("sourcename");
                dtData.Columns.Add(dtColumn2);

                DataColumn dtColumn3 = new DataColumn("eventid");
                dtData.Columns.Add(dtColumn3);

                DataColumn dtColumn4 = new DataColumn("message");
                dtData.Columns.Add(dtColumn4);

                // Set its "direction" parameter to "BW"
                oEVTInputFormat.direction = "BW";

                // Create the query
                string query = @"SELECT TOP " + strNumberOfEvents + " TimeGenerated, SourceName, EventID, Message FROM " + strEventLog;

                // Execute the query
                LogRecordSet oRecordSet = oLogQuery.Execute(query, oEVTInputFormat);

                // Browse the recordset
                for (; !oRecordSet.atEnd(); oRecordSet.moveNext())
                {
                    LogRecord oRecord = oRecordSet.getRecord();
                    DataRow row = dtData.NewRow();

                    row[0] = oRecord.getValue(0);
                    row[1] = oRecord.getValue(1);
                    row[2] = oRecord.getValue(2);
                    row[3] = oRecord.getValue(3);

                    dtData.Rows.Add(row);

                   // Console.WriteLine(oRecordSet.getRecord().toNativeString(","));
                }

                // Close the recordset
                oRecordSet.close();

                DataSet ds = new DataSet();
                ds.Tables.Add(dtData);

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (System.Runtime.InteropServices.COMException exc)
            {
                //Console.WriteLine("Unexpected error: " + exc.Message);
            }


        }

        private void Top10Events(string strEventLogName)
        {
            try
            {

                // Instantiate the LogQuery object
                LogQuery oLogQuery = new LogQuery();

                // Instantiate the Event Log Input Format object
                EventLogInputFormat oEVTInputFormat = new EventLogInputFormat();

                // Instantiate the data tables, columns and rows....
                DataTable dtData = new DataTable("results");
                DataColumn dtColumn = new DataColumn("hits");
                dtData.Columns.Add(dtColumn);

                DataColumn dtColumn2 = new DataColumn("sourcename");
                dtData.Columns.Add(dtColumn2);

                // Create the query
                string query = @"SELECT TOP 10 distinct count(*) as hits, SourceName FROM " + strEventLogName + " where eventtype='1' group by sourcename order by hits desc";

                // Execute the query
                LogRecordSet oRecordSet = oLogQuery.Execute(query, oEVTInputFormat);

                // Browse the recordset
                for (; !oRecordSet.atEnd(); oRecordSet.moveNext())
                {
                    LogRecord oRecord = oRecordSet.getRecord();
                    DataRow row = dtData.NewRow();

                    row[0] = oRecord.getValue(0);
                    row[1] = oRecord.getValue(1);
                  
                    dtData.Rows.Add(row);

                    // Console.WriteLine(oRecordSet.getRecord().toNativeString(","));
                }

                // Close the recordset
                oRecordSet.close();

                DataSet ds = new DataSet();
                ds.Tables.Add(dtData);

                if (strEventLogName == "APPLICATION")
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }
                else
                {
                    GridView3.DataSource = ds;
                    GridView3.DataBind();
                }

                //GridView1.DataSource = ds;
                //GridView1.DataBind();
            }
            catch (System.Runtime.InteropServices.COMException exc)
            {
                //Console.WriteLine("Unexpected error: " + exc.Message);
                lblAppEvtError.Text = "[Unexpected error: " + exc.Message + "]";
            }

        }

        
    }
}