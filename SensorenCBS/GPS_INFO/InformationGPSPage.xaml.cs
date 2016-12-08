using System; using System.Collections.Generic; using System.Diagnostics; using System.Threading.Tasks; using DeviceMotion.Plugin; using DeviceMotion.Plugin.Abstractions; using Plugin.Geolocator; using Xamarin.Forms;  namespace SensorenCBS { 	public partial class InformationGPSPage : ContentPage 	{
		// Hier mee roep je de plugin aan om te kunnen gebruiken
		Plugin.Geolocator.Abstractions.IGeolocator locator = CrossGeolocator.Current;  		public const int Timeout = 30 * 1000; // 30s 		public const double DefaultAccurancy = 1000; // 1000m  		public InformationGPSPage() 		{ 			InitializeComponent(); 			gpsInfo();  			Device.StartTimer(new TimeSpan(0, 0, 10), () => 			{
				// do something every 10 seconds
				gpsInfo(); 				return true; // runs again, or false to stop
			}); 		}

		#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void         async void gpsInfo()
		#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void         { 			try 			{ 				//lblInfo.Text = "Fetching your location"; 				locator.DesiredAccuracy = DefaultAccurancy; // de gewenste nauwkeurigheid in meters  				var position = await locator.GetPositionAsync(timeoutMilliseconds: Timeout); // Geeft de tijd aan hoelang er maximaal gewacht gaat worden om de locatie te kunnen ophalen 				if (position == null) // dus geen locatie door gekregen
				{ 					lblInfo.Text = "There is no GPS Information"; 					lblSpeed.Text = ""; 					lblHeading.Text = ""; 					return; 				}

				lblInfo.Text =
					string.Format("Time : {0}\nLat: {1}\nLong: {2}\nAccuracy: {3:0.0000}",
								position.Timestamp, position.Latitude, position.Longitude, position.Accuracy); 				searchHeading();  			} 			catch (TaskCanceledException) 			{ 				lblInfo.Text = "There is no GPS Information"; 				await DisplayAlert("Error Location", "Fetching the location takes to much time", "OK"); 			}  		}  		void searchHeading() 		{ 			CrossDeviceMotion.Current.Start(MotionSensorType.Compass, MotionSensorDelay.Default); 			CrossDeviceMotion.Current.SensorValueChanged += (s, a) => 			{ 				switch (a.SensorType) 				{ 					case MotionSensorType.Compass: 						var cmd = new CompasMotionDetect(lblHeading, a); 						break; 				} 			}; 		} 	} }  