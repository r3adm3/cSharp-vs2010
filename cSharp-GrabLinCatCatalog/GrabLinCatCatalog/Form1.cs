using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections.Generic;
using HtmlAgilityPack;


namespace GrabLinCatCatalog
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            //toolStripStatusLabel1.Text = "Querying Lincat...";

            //grab page front page from website
            GetPage();

            toolStripStatusLabel1.Text = "Building Category List...";
            
            //construct list of each product, from the subcategories
            foreach (string val in ListTest._List)
            {
                //textBox1.Test = "test";
                listBox1.Items.Add(val.ToString());
            }
        }

        public static void GetProductList(string url)
        {
            //use htmlagility class again to find link for each product. 
     
            //
        }


        public static void GetProductData(string url)
        {

        }

        private static void GetPage()
        {
            // The HtmlWeb class is a utility class to get the HTML over HTTP
            HtmlWeb htmlWeb = new HtmlWeb();

            // Creates an HtmlDocument object from an URL
            HtmlAgilityPack.HtmlDocument document = htmlWeb.Load("http://www.lincat.co.uk/products/range");

            // Targets a specific node
            HtmlNode someNode = document.GetElementbyId("nav-main");

            // If there is no node with that Id, someNode will be null
            if (someNode != null)
            {
                // Extracts all links within that node
                IEnumerable<HtmlNode> allLinks = someNode.Descendants("a");

                // Outputs the href for external links
                foreach (HtmlNode link in allLinks)
                {
                    // Checks whether the link contains an HREF attribute
                    if (link.Attributes.Contains("href"))
                    {
                        // Simple check: if the href begins with "http://", prints it out
                        if (link.Attributes["href"].Value.StartsWith("/products/range"))
                        {
                            ListTest.Record(link.Attributes["href"].Value);
                            //  Console.WriteLine(link.Attributes["href"].Value);
                        }
                    }
                }
            }
            


            /*
            string url = "http://www.lincat.co.uk";
            string strResult = "";

            WebResponse objResponse;
            WebRequest objRequest = System.Net.HttpWebRequest.Create(url);

            objResponse = objRequest.GetResponse();

            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                strResult = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }
            */
            //return strResult;
        }

    }

    

    static class ListTest
    {
        public static List<string> _List;

        static ListTest()
        {
            _List = new List<string>();
        }

        public static void Record(string value)
        {
            _List.Add(value);
        }

        public static int Count()
        {
            return _List.Count;
        }

        public static string Display()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var value in _List)
            {
                sb.AppendLine(value);
            }

            return sb.ToString();

        }
    }
}
