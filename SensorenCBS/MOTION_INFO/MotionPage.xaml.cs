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
			CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer);
			CrossDeviceMotion.Current.SensorValueChanged += (s, a) =>
			{

				switch (a.SensorType)
				{

					case MotionSensorType.Accelerometer:
						Debug.WriteLine("A: {0},{1},{2}", ((MotionVector)a.Value).X, ((MotionVector)a.Value).Y, ((MotionVector)a.Value).Z);
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
