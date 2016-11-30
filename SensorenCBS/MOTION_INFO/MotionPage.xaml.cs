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
		private float[] mGravity;
		private float mAccel;
		private float mAccelCurrent;
		private float mAccelLast;
		private int opgetild = 0;


		public MotionPage()
		{
			InitializeComponent();


			mAccelLast = 9.80665f;
			mAccelCurrent = 9.80665f;
			mAccel = 0.00f;


			//CrossDeviceMotion.Current.Start(MotionSensorDelay.Default);

			CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer, MotionSensorDelay.Default);
			CrossDeviceMotion.Current.SensorValueChanged += (s, a) =>
			{

				switch (a.SensorType)
				{
					
					case MotionSensorType.Accelerometer:

						//Debug.WriteLine("A: {0},{1},{2}", ((MotionVector)a.Value).X, ((MotionVector)a.Value).Y, ((MotionVector)a.Value).Z);

						//lblX.Text = "X: " + ((MotionVector)a.Value).X;
						//lblY.Text = "Y: " + ((MotionVector)a.Value).Y;
						//lblZ.Text = "Z: " + ((MotionVector)a.Value).Z;
						float xx = (float)((MotionVector)a.Value).X;
						float yy = (float)((MotionVector)a.Value).Y;
						float zz = (float)((MotionVector)a.Value).Z;


						mAccelLast = mAccelCurrent;
						mAccelCurrent = (float)Math.Sqrt(xx * xx + yy * yy + zz * zz);
						float delta = mAccelCurrent - mAccelLast;
						Debug.WriteLine("mAccel = {0}", mAccel); // mAccel is gelijk aan x tot dat er een keer bewogen is

						mAccel = mAccel * 1.0f + delta;
						if (mAccel > 2)
						{
							opgetild++;
							lblOp.Text = opgetild.ToString();
							Debug.WriteLine("mAccel = {0} * {1} + {2} ", mAccel, 0.7f, delta);
							Debug.WriteLine("mAccel: {0},Delta: {1},mAccelLast: {2}, mAccelCurrent {3}", mAccel.ToString(), delta.ToString(), mAccelLast.ToString(), mAccelCurrent.ToString());
							//lblAccel.Text = ("mAccel: {0}, delta: {1}, mAccelLast {2}, mAccelCurrent {3}", mAccel.ToString(), delta.ToString(), mAccelLast.ToString(), mAccelCurrent.ToString());
							lblAccel.Text = "Something happend: " + DateTime.Now;
						}

						lblZ.Text = zz.ToString();
						lblX.Text = xx.ToString();
						lblY.Text = yy.ToString();

						break;

				}
			};

			CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer);

		}
	}
}
