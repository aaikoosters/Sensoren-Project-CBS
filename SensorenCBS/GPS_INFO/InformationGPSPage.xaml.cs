﻿using System; using System.Collections.Generic; using System.Diagnostics; using System.Threading.Tasks; using DeviceMotion.Plugin; using DeviceMotion.Plugin.Abstractions; using Plugin.Geolocator; using Xamarin.Forms;  namespace SensorenCBS { 	public partial class InformationGPSPage : ContentPage 	{
		// Hier mee roep je de plugin aan om te kunnen gebruiken
		Plugin.Geolocator.Abstractions.IGeolocator locator = CrossGeolocator.Current;  		public const int Timeout = 30 * 1000; // 30s 		public const double DefaultAccurancy = 1000; // 1000m 		int refreshTime = 10; // 10s 		List<double> totalDistance = new List<double>(); 		double totDistance; // all totalDistance[] added en counted to one value 		double? oldLat; 		double? oldLng; 		DateTime startTime;   		public InformationGPSPage() 		{ 			InitializeComponent(); 			gpsInfo();  			Device.StartTimer(new TimeSpan(0, 0, refreshTime), () => 			{
				// do something every 10 seconds
				gpsInfo(); 				lblTotDistance.Text = "Total Distance: " + distanceTotal(); 				lblAvgSpeed.Text = "Average speed: " + avgSpeed() + " m/s";
				return true; // runs again, or false to stop
			}); 		}  		void checkDistance()  		{ 			// Checking if there is added one or more 'distances' added to the stack 			if (totalDistance.Count == 1)
			{ 				// Checking if the first item that is added is equal to 0,  				//if the first distance item is 0 than remove this item. It means you are not moving around 				double lastAdded = totalDistance[totalDistance.Count - 1]; 				if (lastAdded.Equals(0))
				{ 					totalDistance.Remove(totalDistance.Count - 1); 				} 			} 		}  		double avgSpeed() 		{ 			var distance = distanceTotal(); 			var timeSpend = DateTime.Now - startTime; 			var speedAVG = distance / timeSpend.TotalSeconds; 			return speedAVG; 		}  		double distanceTotal() 		{ 			checkDistance(); // checking or your moved or only started the application and still not moving 			foreach (double distanceItem in totalDistance)
			{ 				totDistance += distanceItem; 			} 			return totDistance; 		}

		#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void         async void gpsInfo()
		#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void         { 			try 			{ 				 				locator.DesiredAccuracy = DefaultAccurancy; // de gewenste nauwkeurigheid in meters 				// Geeft de tijd aan hoelang er maximaal gewacht gaat worden om de locatie te kunnen ophalen 				var position = await locator.GetPositionAsync(timeoutMilliseconds: Timeout);  				if (position == null) // there is no location available 
				{ 					lblInfo.Text = "There is no GPS Information"; 					lblSpeed.Text = ""; 					lblHeading.Text = ""; 					return; 				}

				lblInfo.Text =
					string.Format("Time : {0}\nLat: {1}\nLong: {2}\nAccuracy: {3:0.0000}",
								position.Timestamp, position.Latitude, position.Longitude, position.Accuracy); 				searchHeading(); 				var distance = getDistance(position.Latitude, position.Longitude); 				var speed = (distance / refreshTime); 				lblSpeed.Text = string.Format("Distance: {0:0.00}, Speed: {1:0.00}", distance, speed);   			} 			catch (TaskCanceledException) 			{ 				lblInfo.Text = "There is no GPS Information"; 				await DisplayAlert("Error Location", "Fetching the location takes to much time", "OK"); 			}  		}  		double getDistance(double latitude, double longitude) 		{ 			var R = 6371; // earht radius 			var newLat = latitude; 			var newLng = longitude;  			if (oldLat.HasValue && oldLng.HasValue) 			{ 				var dLat = deg2rad((double)(newLat - oldLat)); 				var dLng = deg2rad((double)(newLng - oldLng)); 				var a = 						Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + 					        Math.Cos(deg2rad((double)oldLat)) * Math.Cos(deg2rad(newLat)) * 					        Math.Sin(dLng / 2) * Math.Sin(dLng / 2); 				var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a)); 				var d = (R * c) * 1000; // R*C = is in KM, do this times 1000 and you have 'd' in meters ; 				totalDistance.Add(d); 				oldLat = latitude; 				oldLng = longitude; 				return d; 			} 			else { 				oldLat = latitude; 				oldLng = longitude; 				startTime = DateTime.Now; 				return 0; 			} 		}  		double deg2rad(double degrees) 		{ 			var radialen = degrees * (Math.PI / 180); 			return radialen; 		}   		void searchHeading() 		{ 			CrossDeviceMotion.Current.Start(MotionSensorType.Compass, MotionSensorDelay.Default); 			CrossDeviceMotion.Current.SensorValueChanged += (s, a) => 			{ 				switch (a.SensorType) 				{ 					case MotionSensorType.Compass: 						var cmd = new CompasMotionDetect(lblHeading, a); 						break; 				} 			}; 		} 	} }  