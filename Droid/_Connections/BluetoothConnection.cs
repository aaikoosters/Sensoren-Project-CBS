using System;
using System.Collections.Generic;
using Android.Bluetooth;
using SensorenCBS.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(BluetoothConnection))]
namespace SensorenCBS.Droid
{
	public class BluetoothConnection : IBluetoothConnection
	{
		BluetoothAdapter _bluetoothAdapter;

		public bool isBluetoothOn { get; set; }
		public string bluetoothAddress { get; set; }

		public BluetoothConnection()
		{
			_bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
		}

		public void CheckBluetoothIsEnabled()
		{
			if (_bluetoothAdapter.IsEnabled)
			{
				isBluetoothOn = true;
			}
			else {
				isBluetoothOn = false;
			}
		}

		public void ChangeBluetoothState(bool OnOff)
		{
			if (OnOff) { _bluetoothAdapter.Enable(); }
			else { _bluetoothAdapter.Disable(); }
		}


	}
}

