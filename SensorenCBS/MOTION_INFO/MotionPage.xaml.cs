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

		public MotionPage()
		{
			InitializeComponent();

			var slow = (MotionSensorDelay)01000000000;
			var counter = 10;
			var getal = 1;

			//CrossDeviceMotion.Current.Start(MotionSensorDelay.Default);

			CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer, MotionSensorDelay.Default);
			CrossDeviceMotion.Current.SensorValueChanged += (s, a) =>
			{

				switch (a.SensorType)
				{
					
					case MotionSensorType.Accelerometer:
						Debug.WriteLineIf(slow.Equals(counter), " slow is geweest on update");
						getal++;
						Debug.WriteLine(slow + ",A " + getal);
						//Debug.WriteLine("A: {0},{1},{2}", ((MotionVector)a.Value).X, ((MotionVector)a.Value).Y, ((MotionVector)a.Value).Z);

						lblX.Text = "X: " + ((MotionVector)a.Value).X;
						lblY.Text = "Y: " + ((MotionVector)a.Value).Y;
						lblZ.Text = "Z: " + ((MotionVector)a.Value).Z;
						break;

				}
			};

			CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer);

		}
	}
}
