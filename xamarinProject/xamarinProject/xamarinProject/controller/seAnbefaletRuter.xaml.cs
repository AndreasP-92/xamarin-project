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
    public partial class seAnbefaletRuter : ContentPage
    {
        public seAnbefaletRuter()
        {
            InitializeComponent();
        }
        public async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        public async void ToFrederiksøMaps_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new maps());
        }
    }
}