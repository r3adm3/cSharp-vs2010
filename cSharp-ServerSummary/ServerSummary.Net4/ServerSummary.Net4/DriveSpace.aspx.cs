using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Management;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

namespace ServerSummary.Net4
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher moDisks = new ManagementObjectSearcher("select * from win32_LogicalDisk");
            double dblCFreeSpace = 0;
            double dblCUsedSpace = 0;
            double dblDFreeSpace = 0;
            double dblDUsedSpace = 0;

            foreach (ManagementObject moDisk in moDisks.Get())
            {
                if (moDisk["name"].ToString() == "C:")
                {
                    dblCFreeSpace = (double)Convert.ToDouble(moDisk["Freespace"]);
                    dblCUsedSpace = (double)Convert.ToDouble(moDisk["size"]) - dblDFreeSpace;
                }
                if (moDisk["name"].ToString() == "D:")
                {
                    dblDFreeSpace = (double)Convert.ToDouble(moDisk["Freespace"]);
                    dblDUsedSpace = (double)Convert.ToDouble(moDisk["size"]) - dblDFreeSpace;
                }
            }

            double[] yValuesC = { dblCFreeSpace, dblCUsedSpace };
            string[] xValuesC = { "Free", "Used" };

            DriveChartsC.Series["DefaultC"].Points.DataBindXY(xValuesC, yValuesC);
            DriveChartsC.Series["DefaultC"].Points[0].Color = Color.MediumSeaGreen;
            DriveChartsC.Series["DefaultC"].Points[1].Color = Color.PaleGreen;

            DriveChartsC.Series["DefaultC"].ChartType = SeriesChartType.Pie;

            DriveChartsC.Series["DefaultC"]["PielabelStyle"] = "Disabled";

            DriveChartsC.ChartAreas["ChartAreaC"].Area3DStyle.Enable3D = true;

            DriveChartsC.Legends[0].Enabled = true;

            double[] yValuesD = { dblDFreeSpace, dblDUsedSpace };
            string[] xValuesD = { "Free", "Used" };

            DriveChartsD.Series["DefaultD"].Points.DataBindXY(xValuesD, yValuesD);
            DriveChartsD.Series["DefaultD"].Points[0].Color = Color.MediumSeaGreen;
            DriveChartsD.Series["DefaultD"].Points[1].Color = Color.PaleGreen;

            DriveChartsD.Series["DefaultD"].ChartType = SeriesChartType.Pie;

            DriveChartsD.Series["DefaultD"]["PielabelStyle"] = "Disabled";

            DriveChartsD.ChartAreas["ChartAreaD"].Area3DStyle.Enable3D = true;

            DriveChartsD.Legends[0].Enabled = true;
        }
    }
}
