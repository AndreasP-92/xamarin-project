
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using xamarinProject.model;

namespace xamarinProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class maps : ContentPage
    {


        public maps()
        {
            InitializeComponent();
            UpdateMap();
        }

        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private void UpdateMap()
        {

            try
            { 
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://10.0.2.2:25556/CoordInfo/getAllCoordinates"));

                WebReq.Method = "GET";

                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

                Console.WriteLine(WebResp.StatusCode);
                Console.WriteLine(WebResp.Server);

                string jsonString;
                using (Stream stream = WebResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    jsonString = reader.ReadToEnd();
                }
                Console.WriteLine("============= INIT PLACES ===========");


                Root initPlaces = JsonConvert.DeserializeObject<Root>(jsonString);
                List<PlacePin> pinList = new List<PlacePin>();

                Console.WriteLine(initPlaces.features);
                foreach (Features place in initPlaces.features)
                {
                    double lonitute = double.Parse(place.lon, new NumberFormatInfo() { NumberDecimalSeparator = "," });
                    double latitude = double.Parse(place.lat, new NumberFormatInfo() { NumberDecimalSeparator = "," });


                    pinList.Add(new PlacePin
                    {
                        PlaceName = place.name,
                        Location = place.type,
                        Position = new Position(lonitute, latitude)
                    }); ;
                }

                MyMap.ItemsSource = pinList;
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(55.320708, 15.187362), Distance.FromKilometers(0.5)));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}