using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomGPS
{
    public partial class App : Application
    {
        public static double CurrentLon;
        public static double CurrentLat;

        public App ()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

