using System;
using System.Collections.Generic;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;

namespace SensorenCBS
{
	public class AccelerometerMotionDetect
	{
		public float xAccel { get; set; }
		public float yAccel { get; set; }
		public float zAccel { get; set; }
		public int pickedPhoneUp { get; set;}
		public float acceleration { get; set;}

		public AccelerometerMotionDetect(SensorValueChangedEventArgs svca)
		{
			// set delay
			// start processing accelerometer
			AccelerometerDetect(svca);
			pickThePhoneUp();

		}

		public void AccelerometerDetect(SensorValueChangedEventArgs b)
		{
			xAccel = ((float)((MotionVector)b.Value).X);
			yAccel = ((float)((MotionVector)b.Value).Y);
			zAccel = ((float)((MotionVector)b.Value).Z);
		}

		public void pickThePhoneUp()
		{
			// need to uses this one to check if the phone is pucked up
			var _unMappedAccel = (float)Math.Sqrt(xAccel * xAccel + yAccel * yAccel + zAccel * zAccel);
			acceleration = (float)(Math.Round(_unMappedAccel * 10f) / 10f);
		}
	}
}