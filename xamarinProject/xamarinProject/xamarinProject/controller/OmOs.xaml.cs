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
using xamarinProject.model;

namespace xamarinProject.controller
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OmOs : ContentPage
    {
        public string AboutUsLabel { get; set; }
        public OmOs()
        {
            InitializeComponent();
            updateAboutusText();
        }

        private void updateAboutusText()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://10.0.2.2:25556/aboutus/getaboutus"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }
            Console.WriteLine("============= INIT PLACES ===========");


            AboutUsRoot initAboutus = JsonConvert.DeserializeObject<AboutUsRoot>(jsonString);

            Console.WriteLine(initAboutus);
        }
    }
}