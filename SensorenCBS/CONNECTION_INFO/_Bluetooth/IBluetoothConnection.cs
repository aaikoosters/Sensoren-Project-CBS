using System;

using Xamarin.Forms;

namespace SensorenCBS
{
	public interface IBluetoothConnection
	{
		bool isBluetoothOn { get; }
		Array discoverdBluetDevices { get; }

		void CheckBluetoothIsEnabled();
		void DiscoverBluetoothDevices();

	}

}

