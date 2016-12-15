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
			isBluetoothEnabled();
		}

		void isBluetoothEnabled()
		{
			lblStat.Text = bluetooth.isEnabled();
		}
	}
}
