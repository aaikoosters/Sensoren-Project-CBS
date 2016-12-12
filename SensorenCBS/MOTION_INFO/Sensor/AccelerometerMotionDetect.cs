using System;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;

namespace SensorenCBS
{
	public class AccelerometerMotionDetect
	{
		Label _label;
		MotionSensorDelay motionDelay;

		public AccelerometerMotionDetect(Label label, SensorValueChangedEventArgs svca)
		{
			_label = label;
			motionDelay = MotionSensorDelay.Default;
			AccelerometerDetect(svca);

		}

		public void AccelerometerDetect(SensorValueChangedEventArgs b)
		{
			//CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer, motionDelay);

			var xG = ((float)((MotionVector)b.Value).X).ToString("N3");
			var yG = ((float)((MotionVector)b.Value).Y).ToString("N3");
			var zG = ((float)((MotionVector)b.Value).Z).ToString("N3");
			_label.Text = string.Format("Accelerometer\nX: {0}\nY: {1}\nZ: {2}", xG, yG, zG);

		}

		public void pickThePhoneUp()
		{


		}
	}
}

// De acceleratie meter
//mAccelLast = mAccelCurrent;
////mAccelCurrent = (float)Math.Sqrt(xx * xx + yy * yy + zz * zz);
//float deltaAcc = mAccelCurrent - mAccelLast;

//mAccel = mAccel * 0.8f + deltaAcc;
//if (mAccel > 3)
//{
//	//if (xx < 0) { }
//	lblAccel.Text = "Er is geacceleerd: " + DateTime.Now;
//}

////lblZ.Text = "Z: " + zz;
////lblX.Text = "X: " + xx;
////lblY.Text = "Y: " + yy;
//return;
//break;
