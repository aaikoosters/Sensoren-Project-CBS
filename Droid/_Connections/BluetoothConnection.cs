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
<<<<<<< HEAD
		public string bluetoothState { get; set; }
		public string bluetoothName { get; set; }
		public string bluetoothHashCode { get; set; }
		
=======
>>>>>>> origin/Bluetooth

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

<<<<<<< HEAD
		public void DiscoverBluetoothInformation()
		{
			bluetoothAddress = string.Format("Bluetooth address: {0}", _bluetoothAdapter.Address);
			bluetoothState = string.Format("Bluetooth is: {0}", _bluetoothAdapter.State);
			bluetoothName = string.Format("Bluetooth name: {0}", _bluetoothAdapter.Name);
		}
=======
>>>>>>> origin/Bluetooth

	}
}

