using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarinProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRR : ContentPage
    {
        public QRR()
        {
            InitializeComponent();
        }

        public async void Historier_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MFErtholm());
        }
    }
}