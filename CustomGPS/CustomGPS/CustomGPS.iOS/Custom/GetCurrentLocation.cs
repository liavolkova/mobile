using System;
using CustomGPS.Custom;
using Xamarin.Forms;
using Plugin.Geolocator;
using System.Threading.Tasks;

[assembly: Dependency(typeof(CustomGPS.iOS.Custom.GetCurrentLocation))]

namespace CustomGPS.iOS.Custom
{
    public class GetCurrentLocation : ICurrentLocation
    {
        public event EventHandler LocationUpdated;

        public GetCurrentLocation()
		{

		}

        

        public void UpdateCurrentLocation()
        {
            //get gps location
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 100;

            locator.GetPositionAsync(TimeSpan.FromSeconds(10)).ContinueWith(t =>
            {
                App.CurrentLat = t.Result.Latitude;
                App.CurrentLon = t.Result.Longitude;

                //flag proccess as done
                LocationUpdated(null, null);

            }, TaskScheduler.FromCurrentSynchronizationContext());

            
        }
    }
}

