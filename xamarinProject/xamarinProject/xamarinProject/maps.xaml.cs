using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

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

        List<Place> placesList = new List<Place>();

        private void UpdateMap()
        {
            try
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(maps)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("xamarinProject.Places.json");
                string text = string.Empty;
                using (var reader = new StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                }

                var resultObject = JsonConvert.DeserializeObject<Places>(text);

                foreach (var place in resultObject.features)
                {
                    placesList.Add(new Place
                    {
                        PlaceName = place.properties.Name,
                        Location = place.geometry.type,
                        Position = new Position(place.geometry.coordinates[1], place.geometry.coordinates[0]) //Latitude is a measurement on a globe or map of location north or south of the Equator. (Lat comes first), Longitude is a measurement of location east or west of the prime meridian at Greenwich. (Comes second)
                    });
                }
                
                MyMap.ItemsSource = placesList;
                //MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(47.6370891183, -122.123736172), Distance.FromKilometers(100)));

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }


        }
    }
}