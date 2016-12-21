using System;

using Xamarin.Forms;

namespace SensorenCBS
{
	public interface IBluetoothConnection
	{
		bool isBluetoothOn { get; }

		void CheckBluetoothIsEnabled();
		void ChangeBluetoothState(bool OnOff);

	}

}

