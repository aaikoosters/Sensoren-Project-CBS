using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SensorenCBS
{
	public interface IBluetoothConnection
	{
		bool isBluetoothOn { get; }
		Dictionary<string, string> discoverdBluetDevices { get; }

		void CheckBluetoothIsEnabled();
		void DiscoverBluetoothDevices();
		void ChangeBluetoothState(bool OnOff);

	}

}

