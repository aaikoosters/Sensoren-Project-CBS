using System;
using Xamarin.Forms;

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
	}
}
