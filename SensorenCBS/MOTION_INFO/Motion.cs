using System;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;

namespace SensorenCBS
{
	public class Motion
	{
		public Motion()
		{
			CrossDeviceMotion.Current.Start(MotionSensorType.Gyroscope, MotionSensorDelay.Default);
			CrossDeviceMotion.Current.Start(MotionSensorType.Magnetometer, MotionSensorDelay.Default);
			CrossDeviceMotion.Current.Start(MotionSensorType.Compass, MotionSensorDelay.Default);
			CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer, MotionSensorDelay.Default);
		}



		public void motionDetect()
		{
			CrossDeviceMotion.Current.SensorValueChanged += (s, a) =>
			{

				switch (a.SensorType)
				{

					case MotionSensorType.Gyroscope:

						var xG = ((float)((MotionVector)a.Value).X).ToString("N3");
						var yG = ((float)((MotionVector)a.Value).Y).ToString("N3");
						var zG = ((float)((MotionVector)a.Value).Z).ToString("N3");
						//lblGyro.Text = (string.Format("X: {0}\nY: {1}\nZ: {2}", xG, yG, zG));
						break;

					case MotionSensorType.Accelerometer:

						var xA = (float)((MotionVector)a.Value).X;
						var yA = (float)((MotionVector)a.Value).Y;
						var zA = (float)((MotionVector)a.Value).Z;
						//lblAcc.Text = string.Format("X: {0}\nY: {1}\nZ: {2}", xA.ToString("N3"), yA.ToString("N3"), zA.ToString("N3"));
						break;

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

						case MotionSensorType.Compass:
						var or = (a.Value.Value);
						String.Format("{0:0.00}", or);
							//lblCom.Text = string.Format("Orientation: {0}", or);
							//lblCom.Text = heading(or);
						break;

					case MotionSensorType.Magnetometer:
							
						var xM = (float)((MotionVector)a.Value).X; xM.ToString("N3");
						var yM = (float)((MotionVector)a.Value).Y; xM.ToString("N3");
						var zM = (float)((MotionVector)a.Value).Z; xM.ToString("N3");
						//lblMag.Text = string.Format("X: {0}\nY: {1}\nZ: {2}", xM, yM, zM);
						break;

				}
			};
			//CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer);
		}
	}
}
