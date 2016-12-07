using System;
using System.Diagnostics;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;

namespace SensorenCBS
{
	public class Motion
	{

		public void atributes()
		{


		}
		Label _label;
		MotionSensorDelay delayDefault; 
		public Motion(Label label)
		{
			if (label == null) { throw new ArgumentNullException(nameof(label)); }
			_label = label;

			delayDefault = MotionSensorDelay.Default;
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
