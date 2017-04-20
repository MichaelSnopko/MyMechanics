using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Net;
using static MyMechanic.LocalShops;
using Newtonsoft.Json;
using Android.Content;

namespace MyMechanic
{
    [Activity(Label = "MyMechanic", MainLauncher = false, Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
        private ListView autoListView;
        private List<string> autoList;
        public const string API = "https://michaelsnopko.github.io/AutoAPI/api.json";
        public string json;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var json = new WebClient().DownloadString(API);
            SetContentView(Resource.Layout.Main);
            RootObject r = JsonConvert.DeserializeObject<RootObject>(json);
            autoListView = FindViewById<ListView>(Resource.Id.autoListView);
            autoList = new List<string>();

            for (int i = 0; i < 38; i++)
            {
                autoList.Add("\n\nName: " + r.listings[i].name + "\n\nAddress: " + r.listings[i].address);
            }
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, autoList);
            autoListView.Adapter = adapter;
            autoListView.ItemClick += Click;
        }

        private void Click(object sender, AdapterView.ItemClickEventArgs e)
        {
            RootObject r = JsonConvert.DeserializeObject<RootObject>(json);
            for (int i = 0; i < 38; i++)
            {
                Listing.(r.listings[i].name);
            }

            string dataLink = "https://www.google.ca/maps/place/" + (e.Position) + r.listings[0].name;
            var uri = Android.Net.Uri.Parse(dataLink);
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);

            //string myString = [e.Position].address;
            //string[] myArray = new string[myString.Length];
            //for (int i = 0; i < myString.Length; i++)
            //{
            //    myArray[i] = myString[i].ToString();
            //}
        }

    }

}

