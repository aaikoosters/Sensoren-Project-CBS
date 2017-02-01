using System;
using System.Diagnostics;
using Plugin.Geolocator;

namespace SensorenCBS
{
	public class FetchingGPS
	{
		public const double DefaultAccurancy = 1000; // 1000m

		Plugin.Geolocator.Abstractions.IGeolocator locator = CrossGeolocator.Current;

		public async void FetchGPS()
		{
			object BindingContext = new LocationDB();
			var _fetchGPS = (LocationDB)BindingContext;

			locator.DesiredAccuracy = DefaultAccurancy;

			if (locator.IsGeolocationEnabled)
			{
				var _position = await locator.GetPositionAsync();
				_fetchGPS.Time = DateTime.Now;
				_fetchGPS.Longitude = _position.Longitude;
				_fetchGPS.Latitude = _position.Latitude;
				_fetchGPS.Accuracy = _position.Accuracy;

			}
		}
	}
}
