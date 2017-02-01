using System;
using System.Diagnostics;
using Plugin.Geolocator;

namespace SensorenCBS
{
	public class FetchingGPS
	{
		public const double DefaultAccurancy = 100; // 100m
		Plugin.Geolocator.Abstractions.IGeolocator locator = CrossGeolocator.Current;

		public DateTime time { get; set; }
		public double Longitude { get; set; }
		public double Latitude { get; set; }
		public double Accuracy { get; set; }

		public async void FetchGPS()
		{
		//	object BindingContext = new LocationDB();
		//	var _fetchGPS = (LocationDB)BindingContext;

			locator.DesiredAccuracy = DefaultAccurancy;

			if (locator.IsGeolocationEnabled)
			{
				var _position = await locator.GetPositionAsync();
				time = DateTime.Now;
				Longitude = _position.Longitude;
				Latitude = _position.Latitude;
				Accuracy = _position.Accuracy;

			}
		}
	}
}
