using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamarinProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new omOs());
        }
    }
}
