using System;
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

		public Array discoverdBluetDevices { get; set; }

		public BluetoothConnection()
		{
		}

		public void CheckBluetoothIsEnabled()
		{
			_bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
			if (_bluetoothAdapter.IsEnabled)
			{
				isBluetoothOn = true;
			}
			else {
				isBluetoothOn = false;
			}
		}

		public void DiscoverBluetoothDevices()
		{
			_bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
			_bluetoothAdapter.StartDiscovery();
		}



	}
}

