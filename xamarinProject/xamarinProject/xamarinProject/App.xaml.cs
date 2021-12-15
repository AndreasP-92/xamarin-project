using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarinProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                //MainPage = new QR();
                BarBackgroundColor = Color.FromHex("#515151"),
                BarTextColor = Color.FromHex("#e4c90e"),
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
