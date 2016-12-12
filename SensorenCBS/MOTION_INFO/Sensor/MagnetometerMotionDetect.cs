using System;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;

namespace SensorenCBS
{
	public class MagnetometerMotionDetect
	{
		Label _label;
		MotionSensorDelay motionDelay;

		public MagnetometerMotionDetect(Label label, SensorValueChangedEventArgs svca)
		{
			_label = label;
			motionDelay = MotionSensorDelay.Default;
			MagnetometerDetect(svca);

		}

		public void MagnetometerDetect(SensorValueChangedEventArgs b)
		{
			CrossDeviceMotion.Current.Start(MotionSensorType.Magnetometer, motionDelay);

			var xG = ((float)((MotionVector)b.Value).X).ToString("N1");
			var yG = ((float)((MotionVector)b.Value).Y).ToString("N1");
			var zG = ((float)((MotionVector)b.Value).Z).ToString("N1");
			_label.Text = string.Format("Magnetometer\nX: {0}\nY: {1}\nZ: {2}", xG, yG, zG);

		}
	}
}
