using System;
using System.Collections.Generic;
using System.Diagnostics;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.Extensions;
using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class BluetoothPage : ContentPage
	{
		//Bluetooth _bluetooth = new Bluetooth();
		IBluetoothLE _ble;
		IAdapter _adapter;
		IDevice _devices;
		List<IDevice> _deviceList = new List<IDevice>();



		public BluetoothPage()
		{
			InitializeComponent();
		}

	}
}
