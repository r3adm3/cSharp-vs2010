using System;
using System.Collections.Generic;
using System.Text;

namespace GrabLinCatCatalog
{
    class URLList
    {
        public string url
        {
            get;
            set;
        }

    }

    class URLCollection : System.Collections.CollectionBase
    {
        public void Add(string url)
        {
            List.Add(url);
        }


    }
}
