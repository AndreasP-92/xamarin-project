using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace xamarinProject
{
    public partial class QRPage : ContentPage
    {
        public QRPage()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
        //    throw new NotImplementedException();
        }

        private async void Button_Clicked(object sender, EventArgs e)
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
    }
}