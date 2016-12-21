using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class BluetoothPage : ContentPage
	{
		Bluetooth bluetooth = new Bluetooth();

		public BluetoothPage()
		{
			InitializeComponent();
			startMethods();

		}

		void startMethods()
		{
			Device.StartTimer(new TimeSpan(0, 0, 2), () =>
			{
				bluetoothInfo();
				return false;
			});
		}

		void btnConnOn(object s, EventArgs e)
		{
			bluetooth.changeState(true);
			startMethods();
		}

		void btnConnOff(object s, EventArgs e)
		{
			bluetooth.changeState(false);
			startMethods();

		}

<<<<<<< HEAD
		void bluetoothInfo()
		{
			lblAbled.Text = bluetooth.isEnabled();
			lblAddress.Text = bluetooth.bluetoothAddress();
			lblState.Text = bluetooth.bluetoothState();
			lblName.Text = bluetooth.bluetoothName();
		}
=======

		//void btnBlueCon(object ob, EventArgs ea)
		//{

		//}
>>>>>>> origin/Bluetooth
	}
}
