using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarinProject.controller;
using xamarinProject.model;

namespace xamarinProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Historier : ContentPage
    {
        public Historier()
        {
            InitializeComponent();
            updateHistories();
           
        }

        public void updateHistories()
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

            foreach (Features history in initPlaces.features)
            {
                Button button = new Button
                {
                    Command = new Command(() =>
                    {
                        Navigation.PushAsync(new HistoryDesc(history.name, history.description));
                    }),
                    Text = history.name,
                    //CornerRadius = 10,
                    HeightRequest = 100,
                    //BackgroundColor = Color.FromHex("#515151"),
                    TextTransform = TextTransform.None,
                    FontSize = 20
                };
                historyLayout.Children.Add(button);
            }
        }




    }
}