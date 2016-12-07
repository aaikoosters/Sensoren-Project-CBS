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

		public GyroscopeMotionDetect(Label label, SensorValueChangedEventArgs svca)
		{
			_label = label;
			motionDelay = MotionSensorDelay.Default;
			GyroscopeDetect(svca);

		}

		public void GyroscopeDetect(SensorValueChangedEventArgs b)
		{
			//CrossDeviceMotion.Current.Start(MotionSensorType.Gyroscope, motionDelay);

			var xG = ((float)((MotionVector)b.Value).X).ToString("N3");
			var yG = ((float)((MotionVector)b.Value).Y).ToString("N3");
			var zG = ((float)((MotionVector)b.Value).Z).ToString("N3");
			_label.Text = string.Format("Gyroscope\nX: {0}\nY: {1}\nZ: {2}", xG, yG, zG);

		}
	}
}
