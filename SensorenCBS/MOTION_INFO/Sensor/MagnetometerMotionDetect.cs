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
			// set label
			_label = label;
			// set delay
			motionDelay = MotionSensorDelay.Default;
			// start processing Magnetometer
			MagnetometerDetect(svca);

		}

		public void MagnetometerDetect(SensorValueChangedEventArgs b)
		{
			CrossDeviceMotion.Current.Start(MotionSensorType.Magnetometer, motionDelay);

			var _xM = ((float)((MotionVector)b.Value).X).ToString("N1");
			var _xY = ((float)((MotionVector)b.Value).Y).ToString("N1");
			var _zM = ((float)((MotionVector)b.Value).Z).ToString("N1");
			_label.Text = string.Format("Magnetometer\nX: {0}\nY: {1}\nZ: {2}", _xM, _xY, _zM);

		}
	}
}
