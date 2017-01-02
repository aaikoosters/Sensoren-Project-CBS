using System;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;

namespace SensorenCBS
{
	public class GyroscopeMotionDetect
	{
		Label _label;
		MotionSensorDelay motionDelay;
		public string xGyro { get; set; }
		public string yGyro { get; set; }
		public string zGyro { get; set; }


		public GyroscopeMotionDetect(SensorValueChangedEventArgs svca)
		{
			// set delay
			motionDelay = MotionSensorDelay.Default;
			// start processing gyroscope
			GyroscopeDetect(svca);

		}

		public void GyroscopeDetect(SensorValueChangedEventArgs b)
		{
			xGyro = ((float)((MotionVector)b.Value).X).ToString("N3");
			yGyro = ((float)((MotionVector)b.Value).Y).ToString("N3");
			zGyro = ((float)((MotionVector)b.Value).Z).ToString("N3");
		}
	}
}
