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
			// set label
			_label = label;
			// set delay
			motionDelay = MotionSensorDelay.Default;
			// start processing gyroscope
			GyroscopeDetect(svca);

		}

		public void GyroscopeDetect(SensorValueChangedEventArgs b)
		{
			var _xG = ((float)((MotionVector)b.Value).X).ToString("N3");
			var _yG = ((float)((MotionVector)b.Value).Y).ToString("N3");
			var _zG = ((float)((MotionVector)b.Value).Z).ToString("N3");
			_label.Text = string.Format("Gyroscope\nX: {0}\nY: {1}\nZ: {2}", _xG,_yG,_zG);
		}
	}
}
