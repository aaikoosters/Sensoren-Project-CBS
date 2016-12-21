using System;

using Xamarin.Forms;

namespace SensorenCBS
{
	public interface IBluetoothConnection
	{
		bool isBluetoothOn { get; }
<<<<<<< HEAD
		string bluetoothAddress { get; }
		string bluetoothState { get; }
		string bluetoothName { get; }
=======
>>>>>>> origin/Bluetooth

		void CheckBluetoothIsEnabled();
		void ChangeBluetoothState(bool OnOff);
		void DiscoverBluetoothInformation();

	}

}

