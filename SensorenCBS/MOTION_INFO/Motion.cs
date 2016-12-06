using System;
using System.Diagnostics;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;

namespace SensorenCBS
{
	public class Motion
	{
		Label _label;
		MotionSensorDelay delayDefault; 
		// voorheen was niet zichtbaar/redraw niet op scherm
		public Motion(Label label)
		{
			if (label == null) { throw new ArgumentNullException("label n"); }

			_label = label;
			delayDefault = MotionSensorDelay.Default;

			// 4 drived classes
			// motion based class
			// elke klas 1 van 4 regels met lbl

		}

		public void MagnetometerMotionDetect(MotionSensorType magnetometer)
		{
			
			//_label = lbl;
			CrossDeviceMotion.Current.Start(magnetometer, delayDefault);
			if (MotionSensorType.Magnetometer != magnetometer) { throw new ArgumentException("Magentometer"); }
			CrossDeviceMotion.Current.SensorValueChanged += (s, a) =>
			{
				var xG = ((float)((MotionVector)a.Value).X).ToString("N3");
				var yG = ((float)((MotionVector)a.Value).Y).ToString("N3");
				var zG = ((float)((MotionVector)a.Value).Z).ToString("N3");
				//Debug.WriteLine(string.Format("X: {0}\nY: {1}\nZ: {2}", xG, yG, zG)); // retekent niet op scherm
				//Motion.Gyro = (string.Format("X: {0}\nY: {1}\nZ: {2}", xG, yG, zG));
				_label.Text = string.Format("X: {0}\nY: {1}\nZ: {2}", xG, yG, zG);
			};

		}

		public void AccelerometerMotionDetect(MotionSensorType accelerometer)
		{

			//_label = lbl;
			CrossDeviceMotion.Current.Start(accelerometer, delayDefault);
			if (MotionSensorType.Accelerometer != accelerometer) { throw new ArgumentException("Accelerometer"); }
			
			CrossDeviceMotion.Current.SensorValueChanged += (s, a) =>
			{
				var xA = (float)((MotionVector)a.Value).X;
				var yA = (float)((MotionVector)a.Value).Y;
				var zA = (float)((MotionVector)a.Value).Z;
				_label.Text = string.Format("X: {0}\nY: {1}\nZ: {2}", xA, yA, zA);

			};

		}

		public void CompassMotionDetect(MotionSensorType compass)
		{
			CrossDeviceMotion.Current.Start(compass, delayDefault);
			if (MotionSensorType.Compass != compass) { throw new ArgumentException("Compass"); }
			
			CrossDeviceMotion.Current.SensorValueChanged += (s, a) =>
			{
				var or = (a.Value.Value);
				String.Format("{0:0.00}", or);
				_label.Text = heading(or);
			};

		}

		public void GyroscopeMotionDetect(MotionSensorType gyroscope)
		{
			CrossDeviceMotion.Current.Start(gyroscope, delayDefault);
			if (MotionSensorType.Gyroscope != gyroscope) { throw new ArgumentException("Gyroscope"); }
			
			CrossDeviceMotion.Current.SensorValueChanged += (s, a) =>
			{
				var xG = ((float)((MotionVector)a.Value).X).ToString("N3");
				var yG = ((float)((MotionVector)a.Value).Y).ToString("N3");
				var zG = ((float)((MotionVector)a.Value).Z).ToString("N3");
				_label.Text = (string.Format("X: {0}\nY: {1}\nZ: {2}", xG, yG, zG));
			};

		}

		string heading(double? or)
		{
			string[] caridnals = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };
			return caridnals[(int)Math.Round(((double)or * 10 % 3600) / 225)] + ", " + or;
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
