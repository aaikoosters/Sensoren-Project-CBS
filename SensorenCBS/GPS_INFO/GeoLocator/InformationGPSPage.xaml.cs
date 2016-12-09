﻿using System; using System.Threading.Tasks; using DeviceMotion.Plugin; using DeviceMotion.Plugin.Abstractions; using Plugin.Geolocator; using Xamarin.Forms;   namespace SensorenCBS { 	public partial class InformationGPSPage : ContentPage 	{
		// Hier mee roep je de plugin aan om te kunnen gebruiken
		Plugin.Geolocator.Abstractions.IGeolocator locator = CrossGeolocator.Current;  		public const int Timeout = 30 * 1000; // 30s 		public const double DefaultAccurancy = 1000; // 1000m 		private const int refreshTime = 10; 		double? oldLat; 		double? oldLng;  		public InformationGPSPage() 		{ 			InitializeComponent();

			//gpsInfo();
			Device.StartTimer(new TimeSpan(0, 0, refreshTime), () =>
			{
				gpsInfo();
				return true; 
			}); 		}            async void gpsInfo()         { 			try 			{ 				locator.DesiredAccuracy = DefaultAccurancy; // de gewenste nauwkeurigheid in meters 				var position = await locator.GetPositionAsync(timeoutMilliseconds: Timeout); // Geeft de tijd aan hoelang er maximaal gewacht gaat worden om de locatie te kunnen ophalen 				if (position == null) // dus geen locatie door gekregen
				{ 					lblInfo.Text = "There is no GPS Information"; 					lblSpeed.Text = ""; 					lblHeading.Text = ""; 					return; 				}

				lblInfo.Text =
					string.Format("Time : {0}\nLat: {1}\nLong: {2}\nAccuracy: {3:0.0000}",
								position.Timestamp, position.Latitude, position.Longitude, position.Accuracy); 				searchHeading(); 				var distance = speading(position.Latitude, position.Longitude); 				var speed = (distance / 10.0); 				lblSpeed.Text = string.Format("Afstand: {0:000}, Snelheid: {1:000}", distance, speed);  			} 			catch (TaskCanceledException) 			{ 				lblInfo.Text = "There is no GPS Information"; 				await DisplayAlert("Error Location", "Fetching the location takes to much time", "OK"); 			}  		}
 		double speading(double latitude, double longitude)
		{ 			var R = 6371;
			var newLat = latitude; 			var newLng = longitude;  			if (oldLat.HasValue && oldLng.HasValue)
			{
				var dLat = deg2rad((double)(newLat - oldLat)); 				var dLng = deg2rad((double)(newLng - oldLng)); 				var a =
						Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
					        Math.Cos(deg2rad((double)oldLat)) * Math.Cos(deg2rad(newLat)) * 					        Math.Sin(dLng / 2) * Math.Sin(dLng / 2); 				var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a)); 				var d = (R * c) * 1000 ; 				return d;
			}
			else { 				oldLat = latitude; 				oldLng = longitude; 				return 0; 			}
		}
 		double deg2rad(double v)
		{ 			var stat = v * (Math.PI / 180);
			return stat;
		} 
		void searchHeading() 		{ 			CrossDeviceMotion.Current.Start(MotionSensorType.Compass, MotionSensorDelay.Default); 			CrossDeviceMotion.Current.SensorValueChanged += (s, a) => 			{ 				switch (a.SensorType) 				{ 					case MotionSensorType.Compass: 						var cmd = new CompasMotionDetect(lblHeading, a); 						break; 				} 			}; 		} 		} }  