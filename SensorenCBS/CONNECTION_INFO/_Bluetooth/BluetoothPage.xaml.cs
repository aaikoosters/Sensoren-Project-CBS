using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class BluetoothPage : ContentPage
	{
		// the connection to the bluetooth methodes.
		Bluetooth bluetooth = new Bluetooth();

		public BluetoothPage()
		{
			InitializeComponent();
			startMethods();

		}

		// a wait function so there is time to get the information, otherwise the device is to fast and can not fetch the right information 
		void startMethods()
		{
			Device.StartTimer(new TimeSpan(0, 0, 2), () =>
			{
				bluetoothInfo();
				return false;
			});
		}

		// button function to put bluetooth on
		void btnConnOn(object s, EventArgs e)
		{
			bluetooth.changeState(true);
			startMethods();
		}

		// button function to put bluetooth off
		void btnConnOff(object s, EventArgs e)
		{
			bluetooth.changeState(false);
			startMethods();

		}
		
		// set the labels with the right information
		void bluetoothInfo()
		{
			lblAbled.Text = bluetooth.isEnabled();
			lblAddress.Text = bluetooth.bluetoothAddress();
			lblState.Text = bluetooth.bluetoothState();
			lblName.Text = bluetooth.bluetoothName();
		}
	}
}
