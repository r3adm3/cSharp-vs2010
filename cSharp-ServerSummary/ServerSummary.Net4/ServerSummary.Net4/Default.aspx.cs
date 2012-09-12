using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Management;

namespace ServerSummary.Net4
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.OperatingSystem osinfo = System.Environment.OSVersion;

            lblServerName2.Text = System.Environment.MachineName.ToString();
            lblOSVer.Text = System.Environment.OSVersion.ToString();
            lblOS.Text = GetOSName();
            lblHostName.Text = System.Environment.MachineName.ToString();
            lblInstallDate.Text = osInstallDate().ToString();
            lblSystemBootTime.Text = osLastBootDate().ToString();
            lblSystemManuFacturer.Text = GetManufacturer();
            lblSystemModel.Text = GetModel();
            lblProcessors.Text = System.Environment.ProcessorCount.ToString();
            lblBios.Text = GetBios();
            lblPhysicalMemory.Text = GetMemory();
            lblAvailableMemory.Text = GetFreeMemory();

        }


        private string GetFreeMemory()
        {
            double dblMemory = 0;
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("Select * from Win32_operatingsystem");

            foreach (ManagementObject mo in moSearcher.Get())
            {
                dblMemory = Math.Round(Convert.ToDouble(mo["FreePhysicalMemory"]) / (1024 * 1024),2 );
            }


            return dblMemory.ToString();
        }

        private string GetMemory()
        {
            double dblMemory = 0;
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("Select * from Win32_computersystem");

            foreach (ManagementObject mo in moSearcher.Get())
            {
                dblMemory = Math.Round (Convert.ToDouble(mo["TotalPhysicalMemory"]) / (1024 * 1024),2) ;
            }


            return dblMemory.ToString();
        }


        private string GetBios()
        {
            string strBios = string.Empty;
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("Select * from Win32_bios");

            foreach (ManagementObject mo in moSearcher.Get())
            {
                strBios = mo["Manufacturer"].ToString() + mo["Name"].ToString();
            }


            return strBios;
        }

        private string GetOSName() 
        { 
            System.OperatingSystem os = System.Environment.OSVersion; string osName = "Unknown"; switch (os.Platform) { case System.PlatformID.Win32Windows:            switch (os.Version.Minor) { case 0:                    osName = "Windows 95"; break; case 10:                    osName = "Windows 98"; break; case 90:                    osName = "Windows ME"; break; } break; case System.PlatformID.Win32NT:            switch (os.Version.Major) { case 3:                    osName = "Windws NT 3.51"; break; case 4:                    osName = "Windows NT 4"; break; case 5:                    if (os.Version.Minor == 0)                        osName = "Windows 2000"; else if (os.Version.Minor == 1)                        osName = "Windows XP"; else if (os.Version.Minor == 2)                        osName = "Windows Server 2003"; break; case 6:                    osName = "Windows Vista"; if (os.Version.Minor == 0)                        osName = "Windows Vista"; else if (os.Version.Minor == 1)                        osName = "Windows 7"; break; } break; } 
            return osName; 
        }


        private string GetModel()
        {
            string strModel = string.Empty;
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("Select * from Win32_computerSystem");

            foreach (ManagementObject mo in moSearcher.Get())
            {
                strModel = mo["Model"].ToString();
            }


            return strModel;
        }

        private string GetManufacturer()
        {
            string strManufacturer = string.Empty;
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem");

            foreach (ManagementObject mo in moSearcher.Get())
            {
                strManufacturer = mo["Manufacturer"].ToString();
            }


            return strManufacturer;
        }

        private DateTime osInstallDate()
        {

            DateTime dtmInstallDate = new DateTime();
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("Select * from Win32_OperatingSystem");

            foreach (ManagementObject mo in moSearcher.Get())
            {
                dtmInstallDate = ManagementDateTimeConverter.ToDateTime (mo["InstallDate"].ToString());
            }


            return dtmInstallDate;
        }

        private DateTime osLastBootDate()
        {

            DateTime dtmLastBootDate = new DateTime();
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("Select * from Win32_OperatingSystem");

            foreach (ManagementObject mo in moSearcher.Get())
            {
                dtmLastBootDate = ManagementDateTimeConverter.ToDateTime(mo["LastBootUpTime"].ToString());
            }


            return dtmLastBootDate;
        }

    }
}
