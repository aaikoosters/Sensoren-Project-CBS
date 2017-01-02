using System;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;

namespace SensorenCBS
{
	public class AccelerometerMotionDetect
	{
		MotionSensorDelay motionDelay;

		public string xAccel { get; set; }
		public string yAccel { get; set; }
		public string zAccel { get; set; }

		public AccelerometerMotionDetect(SensorValueChangedEventArgs svca)
		{
			// set delay
			motionDelay = MotionSensorDelay.Default;
			// start processing accelerometer
			AccelerometerDetect(svca);

		}

		public void AccelerometerDetect(SensorValueChangedEventArgs b)
		{
			xAccel = ((float)((MotionVector)b.Value).X).ToString("N3");
			yAccel = ((float)((MotionVector)b.Value).Y).ToString("N3");
			zAccel = ((float)((MotionVector)b.Value).Z).ToString("N3");
		}

		public void pickThePhoneUp()
		{
			// need to uses this one to check if the phone is pucked up
		}
	}
}

// De acceleratie meter
//mAccelLast = mAccelCurrent;
//mAccelCurrent = (float)Math.Sqrt(xx * xx + yy * yy + zz * zz);
//float deltaAcc = mAccelCurrent - mAccelLast;

//mAccel = mAccel * 0.8f + deltaAcc;
//if (mAccel > 3)
//{
//	//if (xx < 0) { }
//	lblAccel.Text = "Er is geacceleerd: " + DateTime.Now;
//}

//lblZ.Text = "Z: " + zz;
//lblX.Text = "X: " + xx;
//lblY.Text = "Y: " + yy;
//return;
//break;
