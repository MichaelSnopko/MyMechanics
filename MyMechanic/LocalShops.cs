using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyMechanic
{
    class LocalShops
    {
        public class Listing
        {
            public string id { get; set; }
            public string name { get; set; }
            public string address { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
        }

        public class RootObject
        {
            public List<Listing> listings { get; set; }
        }
    }
}