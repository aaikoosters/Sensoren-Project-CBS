using System; using System.Collections; using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks; using DeviceMotion.Plugin; using DeviceMotion.Plugin.Abstractions; using Plugin.Geolocator; using Xamarin.Forms;   namespace SensorenCBS { 	public partial class InformationGPSPage : ContentPage 	{ 		FetchingGPS fgps; 		const int _refreshTime = 20; // 10s 		double? _oldLatitude; 		double? _oldLongitude; 		//double[] totalDistance; 		List<double> _distances = new List<double>(); 		double _totalDistance; 		double _avgSpeed;  		public InformationGPSPage() 		{ 			 			InitializeComponent();
			fgps = new FetchingGPS(); 			fgps.FetchGPS();
			// every X seconds the device run this method again
			Device.StartTimer(new TimeSpan(0, 0, _refreshTime), () =>
			{ 				// start fetching GPS info 				fgps.FetchGPS(); 				// do something with the fetched info 				gpsInfo();
				return true; 
			}); 		}            void gpsInfo()         { 			// searching for the direction moving or device is pointing 			searchHeading(); 			var _outputString = string.Format("Time : {0}\nLat: {1}\nLong: {2}\nAccuracy: {3:0.0000}", 			                                  fgps.time, fgps.Latitude, fgps.Longitude, fgps.Accuracy); 			var _distance = GetDistanceM(fgps.Latitude, fgps.Longitude); 			_distances.Add(_distance); 			lblInfo.Text = _outputString;  			foreach (double d in _distances)
			{ 				_totalDistance += d; 			} 			_avgSpeed = (_totalDistance / (_distances.Count - 1)) / 20; 			lblAvgSpeed.Text = "AVG Speed: " + _avgSpeed;
			lblSpeed.Text = string.Format("Total m of movement: {0:0.00}", _totalDistance);   		}
 		const double EARTH_RADIUS_M = 6371e3; 		// http://damien.dennehy.me/blog/2011/01/15/haversine-algorithm-in-csharp/ 		// https://en.wikipedia.org/wiki/Haversine_formula  		public double GetDistanceM(double newLatitude, double newLongitude)
		{ 			if (_oldLatitude.HasValue && _oldLongitude.HasValue) 			{
				double dLat = ToRad((double)(newLatitude - _oldLatitude));
				double dLon = ToRad((double)(newLongitude - _oldLongitude)); // 2 - 1

				double a = Math.Pow(Math.Sin(dLat / 2), 2) +
						   Math.Cos(ToRad((double)_oldLongitude)) * Math.Cos(ToRad(newLongitude)) *
						   Math.Pow(Math.Sin(dLon / 2), 2);

				double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

				double distance = EARTH_RADIUS_M * c; 		//		Debug.WriteLine(string.Format("c:{0} d:{1}", c, d)); 				lblTotDistance.Text += string.Format("\nc:{0} d:{1}", c, distance); 				_oldLatitude = newLatitude;
				_oldLongitude = newLongitude; 				return distance; 				 			} 			_oldLatitude = newLatitude; 			_oldLongitude = newLongitude;
			return 0;
		}  		static double ToRad(double input)
		{
			return input * (Math.PI / 180);
		}  
		void searchHeading() 		{ 			// start the compass sensor 			CrossDeviceMotion.Current.Start(MotionSensorType.Compass, MotionSensorDelay.Default); 			CrossDeviceMotion.Current.SensorValueChanged += (s, a) => 			{ 				switch (a.SensorType) 				{ 					//  					case MotionSensorType.Compass: 						var _cmd = new CompasMotionDetect(a); 						lblHeading.Text = "Heading: " + _cmd.orCompas; 						break; 				} 			}; 		} 	} }  