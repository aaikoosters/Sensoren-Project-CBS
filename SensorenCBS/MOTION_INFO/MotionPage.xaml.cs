using System;
using System.Collections.Generic;
using System.Diagnostics;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class MotionPage : ContentPage
	{
		public const MotionSensorDelay Default = (MotionSensorDelay)1000;
		Motion mtn;
		//float mAccel;
		//float mAccelCurrent;
		//float mAccelLast;
		//int opgetild = 0;



		public MotionPage()
		{
			InitializeComponent();


			//mAccelLast = 9.80665f;
			//mAccelCurrent = 9.80665f;
			//mAccel = 0.00f;

			//accelX();
			//accel();

			verschuiven();
			optillen();

			CrossDeviceMotion.Current.Start(MotionSensorType.Gyroscope, MotionSensorDelay.Default);
			CrossDeviceMotion.Current.Start(MotionSensorType.Magnetometer, MotionSensorDelay.Default);
			CrossDeviceMotion.Current.Start(MotionSensorType.Compass, MotionSensorDelay.Default);
			CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer, MotionSensorDelay.Default);
			//motionDetect();
			//mtn
			mtn = new Motion(lblGyro); 

			// object met bovenstaande om beter te kunnen lezen/begrijpen 

			//lblGyro.Text = mtn.Gyro(MotionSensorType.Gyroscope);
			mtn.MagnetometerMotionDetect(MotionSensorType.Magnetometer);

			//lblGyro.Text = Motion.Gyro;
			//lblMag
			//lblAcc
			//lblGyro



		}


		string naast(MotionSensorType gyroscope)
		{
			throw new NotImplementedException();
		}

		void optillen()
		{
			
		}

		void verschuiven()
		{
			//throw new NotImplementedException();
		} 

		void motionDetect() 
		{
			//CrossDeviceMotion.Current.Start(MotionSensorType.Gyroscope, MotionSensorDelay.Default);
				CrossDeviceMotion.Current.SensorValueChanged += (s, a) =>
				{

					switch (a.SensorType)
					{ 

						case MotionSensorType.Gyroscope:

						var motionVectorValue = a.Value;
							if (motionVectorValue == null)
								throw new Exception("Motion Vector Value is nulls");



							//var motionVector = (MotionVector)motionVectorValue;


							var xG = ((float)((MotionVector)a.Value).X).ToString("N3");
						var yG = ((float)((MotionVector)a.Value).Y).ToString("N3");
						var zG = ((float)((MotionVector)a.Value).Z).ToString("N3");
						lblGyro.Text = (string.Format("X: {0}\nY: {1}\nZ: {2}", xG, yG, zG));
						break;

						case MotionSensorType.Accelerometer:

							//float xx = (float)((MotionVector)a.Value).X;
							//float yy = (float)((MotionVector)a.Value).Y;
							//float zz = (float)((MotionVector)a.Value).Z;
							var xA = (float)((MotionVector)a.Value).X;
							var yA = (float)((MotionVector)a.Value).Y; 
							var zA = (float)((MotionVector)a.Value).Z;
							lblAcc.Text = string.Format("X: {0}\nY: {1}\nZ: {2}", xA.ToString("N3"), yA.ToString("N3"), zA.ToString("N3"));
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
						lblCom.Text = heading(or) + ", " + or;
						break;

						case MotionSensorType.Magnetometer:
							 //return;
							var xM = (float)((MotionVector)a.Value).X; xM.ToString("N3");
							var yM = (float)((MotionVector)a.Value).Y; xM.ToString("N3");
							var zM = (float)((MotionVector)a.Value).Z; xM.ToString("N3");
						lblMag.Text = string.Format("X: {0}\nY: {1}\nZ: {2}", xM, yM, zM);
							break;

					}
				};

				//CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer);
			}

		string heading(double? or)
		{
			string[] caridnals = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };
			return caridnals[(int)Math.Round(((double)or * 10 % 3600) / 225)] + ", " +or;
		}

	}
}

