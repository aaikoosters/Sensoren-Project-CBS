using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;

namespace SensorenCBS
{
	public class MagnetometerMotionDetect
	{
		MotionSensorDelay motionDelay;
		public string xMagn { get; set; }
		public string yMagn { get; set; }
		public string zMagn { get; set; }


		public MagnetometerMotionDetect(SensorValueChangedEventArgs svca)
		{
			// set delay
			motionDelay = MotionSensorDelay.Default;
			// start processing Magnetometer
			MagnetometerDetect(svca);

		}

		public void MagnetometerDetect(SensorValueChangedEventArgs b)
		{
			CrossDeviceMotion.Current.Start(MotionSensorType.Magnetometer, motionDelay);
			xMagn = ((float)((MotionVector)b.Value).X).ToString("N1");
			yMagn = ((float)((MotionVector)b.Value).Y).ToString("N1");
			zMagn = ((float)((MotionVector)b.Value).Z).ToString("N1");
		}
	}
}
