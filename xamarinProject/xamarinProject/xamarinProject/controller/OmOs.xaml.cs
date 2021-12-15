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
            aboutUsText.Text = initAboutus.data[0].aboutUsText;
            //Christiansø er del af øgruppen Ertholmene. Øgruppen er ejet af den danske stat og hører under Forsvarsministeriet. Den ligger ca. 20 km nordøst for Bornholm og består af de to beboede øer Christiansø og Frederiksø, fuglereservatet Græsholm og et antal større og mindre klippeskær. Alt er totalfredet, både fæstning, natur og dyreliv. Der bor i dag ca. 90 mennesker på øerne.
            Console.WriteLine(initAboutus);
        }
    }
}