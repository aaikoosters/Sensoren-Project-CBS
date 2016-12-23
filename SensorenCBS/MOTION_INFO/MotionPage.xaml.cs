using System;
using System.Collections.Generic;
using System.Diagnostics;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class MotionPage : ContentPage
	{
		MotionSensorDelay delayDefault;

		public MotionPage()
		{
			InitializeComponent();
			delayDefault = MotionSensorDelay.Default;
			// start the sensor, in this case you start all four meters
			CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer, delayDefault);
			CrossDeviceMotion.Current.Start(MotionSensorType.Compass, delayDefault);
			CrossDeviceMotion.Current.Start(MotionSensorType.Gyroscope, delayDefault);
			CrossDeviceMotion.Current.Start(MotionSensorType.Magnetometer, delayDefault);

			CrossDeviceMotion.Current.SensorValueChanged += (s, a) =>
			{
				// chose the right type
				switch (a.SensorType)
				{
					// call the right type and set the label with the returned text
					case MotionSensorType.Magnetometer:
						var mmd = new MagnetometerMotionDetect(lblMag, a);
						break;
					case MotionSensorType.Gyroscope:
						var gmd = new GyroscopeMotionDetect(lblGyro, a);
						break;
					case MotionSensorType.Accelerometer:
						var amd = new AccelerometerMotionDetect(lblAcc, a);
						break;
					case MotionSensorType.Compass:
						var cmd = new CompasMotionDetect(lblCom, a);
						break;


				}
			};
		}

	}
}

