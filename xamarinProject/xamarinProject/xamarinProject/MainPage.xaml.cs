using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using xamarinProject.controller;

namespace xamarinProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public async void MFTidsplan_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MFErtholm());
        }
        public async void Sevaerdigheder_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Sevaerdigheder());
        }
        public async void Historier_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Historier());
        }
        public async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new seAnbefaletRuter());
        }

        public async void Omos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OmOs());
        }
    }
}
