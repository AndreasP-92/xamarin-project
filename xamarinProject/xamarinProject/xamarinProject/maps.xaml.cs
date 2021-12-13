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
            //try
            //{
            //    var assembly = IntrospectionExtensions.GetTypeInfo(typeof(maps)).Assembly;
            //    Stream stream = assembly.GetManifestResourceStream("xamarinProject.Places.json");
            //    string text = string.Empty;
            //    using (var reader = new StreamReader(stream))
            //    {
            //        text = reader.ReadToEnd();
            //    }

            //    var resultObject = JsonConvert.DeserializeObject<Places>(text);

            //    foreach (var place in resultObject.features)
            //    {
            //        placesList.Add(new Place
            //        {
            //            PlaceName = place.properties.Name,
            //            Location = place.geometry.type,
            //            Position = new Position(place.geometry.coordinates[1], place.geometry.coordinates[0]) //Latitude is a measurement on a globe or map of location north or south of the Equator. (Lat comes first), Longitude is a measurement of location east or west of the prime meridian at Greenwich. (Comes second)
            //        });
            //    }

            //    MyMap.ItemsSource = placesList;
            //    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(55.320708, 15.187362), Distance.FromKilometers(0.5)));

            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //}

            try
            { 
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://10.0.2.2:25556/CoordInfo/getAllCoordinates"));

                WebReq.Method = "GET";

                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

                Console.WriteLine(WebResp.StatusCode);
                Console.WriteLine(WebResp.Server);

                string jsonString;
                using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
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

                Console.WriteLine(pinList[0]);




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