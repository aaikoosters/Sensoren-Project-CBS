using System; using System.Threading.Tasks; using DeviceMotion.Plugin; using DeviceMotion.Plugin.Abstractions; using Plugin.Geolocator; using Xamarin.Forms;   namespace SensorenCBS { 	public partial class InformationGPSPage : ContentPage 	{
		// Implement plugin so u can use the CrossGeolocator plugin
		Plugin.Geolocator.Abstractions.IGeolocator locator = CrossGeolocator.Current;  		public const int Timeout = 30 * 1000; // 30s 		public const double DefaultAccurancy = 1000; // 1000m 		const int _refreshTime = 10; // 10s 		double? _oldLat; 		double? _oldLng;  		public InformationGPSPage() 		{ 			InitializeComponent();

			// every ** seconds the device run this method again
			Device.StartTimer(new TimeSpan(0, 0, _refreshTime), () =>
			{
				gpsInfo();
				return true; 
			}); 		}            async void gpsInfo()         { 			try 			{ 				// the accuracy in meters 				locator.DesiredAccuracy = DefaultAccurancy;  				// timeout: is maximum time before the method get stuck  				var _position = await locator.GetPositionAsync(Timeout); 				// if position is null there is no location information 				if (_position == null) 
				{ 					lblInfo.Text = "There is no GPS Information"; 					lblSpeed.Text = ""; 					lblHeading.Text = ""; 					return; 				}

				lblInfo.Text =
					string.Format("Time : {0}\nLat: {1}\nLong: {2}\nAccuracy: {3:0.0000}",
								_position.Timestamp, _position.Latitude, _position.Longitude, _position.Accuracy); 				searchHeading(); 				var _distance = speading(_position.Latitude, _position.Longitude); 				var _speed = (_distance / 10.0); 				lblSpeed.Text = string.Format("Afstand: {0:000}, Snelheid: {1:000}", _distance, _speed);  			} 			catch (TaskCanceledException) 			{ 				lblInfo.Text = "There is no GPS Information"; 				await DisplayAlert("Error Location", "Fetching the location takes to much time", "OK"); 			}  		}
		// get 2 geo points to calculate the speed of your movement. 		double speading(double latitude, double longitude)
		{ 			// radius earth 			var _Radius = 6371; 			var _KM = 1000;
			var _newLat = latitude; 			var _newLng = longitude;  			if (_oldLat.HasValue && _oldLng.HasValue)
			{
				var _dLat = deg2rad((double)(_newLat - _oldLat)); 				var _dLng = deg2rad((double)(_newLng - _oldLng)); 				var _a =
						Math.Sin(_dLat / 2) * Math.Sin(_dLat / 2) +
							Math.Cos(deg2rad((double)_oldLat)) * Math.Cos(deg2rad(_newLat)) *
							Math.Sin(_dLng / 2) * Math.Sin(_dLng / 2); 				var _c = 2 * Math.Atan2(Math.Sqrt(_a), Math.Sqrt(1 - _a)); 				var _speading = (_Radius * _c) * _KM; 				return _speading;
			}
			_oldLat = latitude;
			_oldLng = longitude;
			return 0; 		}
 		double deg2rad(double degrees)
		{ 			var _radials = degrees * (Math.PI / 180);
			return _radials;
		} 
		void searchHeading() 		{ 			// start the compass sensor 			CrossDeviceMotion.Current.Start(MotionSensorType.Compass, MotionSensorDelay.Default); 			CrossDeviceMotion.Current.SensorValueChanged += (s, a) => 			{ 				switch (a.SensorType) 				{ 					//  					case MotionSensorType.Compass: 						var _cmd = new CompasMotionDetect(a); 						lblHeading.Text = "Heading: " + _cmd.orCompas; 						break; 				} 			}; 		} 	} }  