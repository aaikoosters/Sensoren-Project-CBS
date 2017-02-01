using System; using System.Threading.Tasks; using DeviceMotion.Plugin; using DeviceMotion.Plugin.Abstractions; using Plugin.Geolocator; using Xamarin.Forms;   namespace SensorenCBS { 	public partial class InformationGPSPage : ContentPage 	{ 		FetchingGPS fgps; 		const int _refreshTime = 10; // 10s 		double? _oldLatitude; 		double? _oldLongitude;  		public InformationGPSPage() 		{ 			InitializeComponent();
			fgps = new FetchingGPS(); 			fgps.FetchGPS();
			// every X seconds the device run this method again
			Device.StartTimer(new TimeSpan(0, 0, _refreshTime), () =>
			{ 				fgps.FetchGPS(); 				gpsInfo();
				return true; 
			}); 		}            void gpsInfo()         {  			searchHeading(); 			var _outputString = string.Format("Time : {0}\nLat: {1}\nLong: {2}\nAccuracy: {3:0.0000}", 			                                  fgps.time, fgps.Latitude, fgps.Longitude, fgps.Accuracy); 			var _speed = distance(fgps.Latitude, fgps.Longitude);  			lblInfo.Text = _outputString;
			lblSpeed.Text = string.Format("Distance of movement: {0:0.0}", _speed);   		}   		double distance(double newLatitude, double newLongitude)
		{ 			if (_oldLatitude.HasValue && _oldLongitude.HasValue)
			{

				double theta = (double)(_oldLongitude - newLongitude); 				double dist =
					Math.Sin(deg2rad((double)_oldLatitude)) * Math.Sin(deg2rad(newLatitude)) +
					Math.Cos(deg2rad((double)_oldLatitude)) * Math.Cos(deg2rad(newLatitude)) * Math.Cos(deg2rad(theta)); 				dist = Math.Acos(dist); 				dist = rad2deg(dist); 				dist = dist * 60 * 1.1515;  				_oldLatitude = newLatitude;
				_oldLongitude = newLongitude;  				return dist * 1.609344; // hard coded kilometer

			} 			_oldLatitude = newLatitude; 			_oldLongitude = newLongitude;
			return 0.0; 		}
 		double deg2rad(double degrees)
		{ 			var _radials = degrees * (Math.PI / 180);
			return _radials;
		}  		double rad2deg(double rad)
		{
			return (rad / Math.PI * 180.0);
		} 
		void searchHeading() 		{ 			// start the compass sensor 			CrossDeviceMotion.Current.Start(MotionSensorType.Compass, MotionSensorDelay.Default); 			CrossDeviceMotion.Current.SensorValueChanged += (s, a) => 			{ 				switch (a.SensorType) 				{ 					//  					case MotionSensorType.Compass: 						var _cmd = new CompasMotionDetect(a); 						lblHeading.Text = "Heading: " + _cmd.orCompas; 						break; 				} 			}; 		} 	} }  