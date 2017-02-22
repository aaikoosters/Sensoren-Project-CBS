using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class BluetoothPage : ContentPage
	{
		Bluetooth _bluetooth = new Bluetooth();

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
			_bluetooth.changeState(true);
			startMethods();
		}

		void btnConnOff(object s, EventArgs e)
		{
			_bluetooth.changeState(false);
			startMethods();
		}

		void bluetoothInfo()
		{
			lblAbled.Text = _bluetooth.isEnabled();
			lblAddress.Text = _bluetooth.bluetoothAddress();
			lblState.Text = _bluetooth.bluetoothState();
			lblName.Text = _bluetooth.bluetoothName();
		}
	}
}
