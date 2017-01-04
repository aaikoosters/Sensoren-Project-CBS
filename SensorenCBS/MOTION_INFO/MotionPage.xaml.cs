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
		MotionSensorDelay delayDefault;
		int pickedPhoneUp { get; set; }
		bool boolPickedUp = false;




		public MotionPage()
		{
			InitializeComponent();
			delayDefault = MotionSensorDelay.Default;
			// start the sensor, in this case you start all four meters
			CrossDeviceMotion.Current.Start(MotionSensorType.Accelerometer, delayDefault);
			CrossDeviceMotion.Current.Start(MotionSensorType.Compass, delayDefault);
			CrossDeviceMotion.Current.Start(MotionSensorType.Gyroscope, delayDefault);
			CrossDeviceMotion.Current.Start(MotionSensorType.Magnetometer, delayDefault);

			CrossDeviceMotion.Current.SensorValueChanged += (s, a) =>
			{
				// chose the right type
				switch (a.SensorType)
				{
					// call the right type and set the label with the returned text
					case MotionSensorType.Magnetometer:
						var mmd = new MagnetometerMotionDetect(a);
						lblMag.Text = string.Format("Magnetometer\nX: {0}\nY: {1}\nZ: {2}", mmd.xMagn, mmd.yMagn, mmd.zMagn);
						break;
					case MotionSensorType.Gyroscope:
						var gmd = new GyroscopeMotionDetect(a);
						if (gmd != null)
						{
							lblGyro.Text = string.Format("Magnetometer\nX: {0}\nY: {1}\nZ: {2}", gmd.xGyro, gmd.yGyro, gmd.zGyro);
						}
						else {
							lblGyro.Text = "Phone does not have a gyroscope";
						}
						break;
					case MotionSensorType.Accelerometer:
						var amd = new AccelerometerMotionDetect(a);
						lblAcc.Text = string.Format("Accelerometer\nX: {0:##.000}\nY: {1:##.000}\nZ: {2:##.000}", amd.xAccel, amd.yAccel, amd.zAccel);
						BindingContext = new CBSItem();
						pickedPhoneUpChecker(amd);

						break;
					case MotionSensorType.Compass:
						var cmd = new CompasMotionDetect(a);
						lblCom.Text = cmd.orCompas;
						break;


				}
			};
		}

		async void pickedPhoneUpChecker(AccelerometerMotionDetect amd)
		{
			if (amd.acceleration < 9 || amd.acceleration > 10)
			{
				if (amd.yAccel > 1 && amd.zAccel < 9)
				{
					boolPickedUp = true;
					//pickedPhoneUp++;
				}
			}
			else
			{
				if (boolPickedUp && amd.yAccel < 1)
				{
					var cbsItem = (CBSItem)BindingContext;
					cbsItem.pickedUp = boolPickedUp;
					cbsItem.timeAndDay = DateTime.Now;
					await App.Database.SaveItemAsync(cbsItem);

					//pickedPhoneUp++;// pipickedPhoneUp;
					boolPickedUp = false;
					//var cbsItem = (CBSItem)BindingContext;
					//await App.Database.SaveItemAsync(cbsItem);
				}
			}
			////Debug.WriteLine(await App.Database.CountPickedUp());
			//List<string> items = new List<string>();
			//items = App.Database.CountPickedUp();
			//lblPickedUp.Text = pickedPhoneUp.ToString();
			//lblPickedUp.Text = App.Database.CountPickedUp().;

			getListItemFromCBS();
			lblPickedUp.Text = pickedPhoneUp.ToString();


		}



		async void getListItemFromCBS()
		{
			List<CBSItem> list = await App.Database.GetItemsAsync();
			pickedPhoneUp = list.Count;
		}
	}
}

