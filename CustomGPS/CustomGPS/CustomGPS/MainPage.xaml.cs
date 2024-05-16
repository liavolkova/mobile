using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomGPS.Custom;
using Xamarin.Forms;

namespace CustomGPS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            DependencyService.Get<ICurrentLocation>().LocationUpdated += delegate
            {
                lblLon.Text = "LON: " + App.CurrentLon.ToString();
                lblLat.Text = "LAT: " + App.CurrentLat.ToString();

            };
        }

        void UpdateLocation_Clicked(System.Object sender, System.EventArgs e)
        {
            DependencyService.Get<ICurrentLocation>().UpdateCurrentLocation();
            
        }

        void Clear_Clicked(System.Object sender, System.EventArgs e)
        {
            lblLon.Text = "LON: 000000";
            lblLat.Text = "LAT: 111111";
        }
    }
}

