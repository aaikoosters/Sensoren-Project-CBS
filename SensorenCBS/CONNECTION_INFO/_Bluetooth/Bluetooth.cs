using System;
using Xamarin.Forms;
using System.Collections.Generic;


namespace SensorenCBS
{
	public class Bluetooth
	{
		IBluetoothConnection bluetoothConnection = DependencyService.Get<IBluetoothConnection>();
		
		public Bluetooth()
		{
		}

		public string isEnabled()
		{
			bluetoothConnection.CheckBluetoothIsEnabled();
			var bluetoothEnabled = bluetoothConnection.isBluetoothOn;
			return bluetoothEnabled ? "Bluetooth is Enabled" : "Bluetooth is Disabled";
		}

		public void changeState(bool change)
		{
			bluetoothConnection.ChangeBluetoothState(change);
			//bluetoothConnection.CheckBluetoothIsEnabled();
			//var bluetoothState = bluetoothConnection.isBluetoothOn;
		}

		public Dictionary<string, string> fetchDevices()
		{
			bluetoothConnection.DiscoverBluetoothDevices();
			return bluetoothConnection.discoverdBluetDevices;
		}
	
	}
}
