using System;
namespace CustomGPS.Custom
{
	public interface ICurrentLocation
	{
		event EventHandler LocationUpdated;
		void UpdateCurrentLocation();
	}
}

