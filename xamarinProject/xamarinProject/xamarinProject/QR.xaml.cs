using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace xamarinProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QR : ContentPage
    {
        public QR()
        {
            InitializeComponent();

        }


        public async void QrButton_OnClicked(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
            await Navigation.PushModalAsync(scan);

            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                    await DisplayAlert("Value QRCode", "" + result.Text, "OK");

                });

            };
        }

        //public async void Historier_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new MFErtholm());
        //}
    }
}