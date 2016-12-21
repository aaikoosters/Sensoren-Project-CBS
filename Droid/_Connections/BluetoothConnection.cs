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
		private HashSet<BluetoothDevice> _pairedDevices;

		public bool isBluetoothOn { get; set; }
		public Dictionary<string, string> discoverdBluetDevices { get; set; }

		public BluetoothConnection()
		{
			_bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
			_pairedDevices = (HashSet<BluetoothDevice>)_bluetoothAdapter.BondedDevices;
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

		public void DiscoverBluetoothDevices()
		{
			var devices = new Dictionary<string, string>();
			foreach (BluetoothDevice bt in _pairedDevices)
			{
				discoverdBluetDevices.Add(bt.Address, bt.Name);
			}
		}

		public void ChangeBluetoothState(bool OnOff)
		{
			_bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
			if (OnOff) { _bluetoothAdapter.Enable();  }
			else { _bluetoothAdapter.Disable(); }
		}

	}
}

