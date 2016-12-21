using System;
using System.Collections.Generic;
using SensorenCBS.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(BluetoothConnection))]
namespace SensorenCBS.iOS
{
	public class BluetoothConnection : IBluetoothConnection
	{
		public BluetoothConnection()
		{
			
		}


		public bool isBluetoothOn { get; set; }

		Dictionary<string, string> IBluetoothConnection.discoverdBluetDevices
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public void ChangeBluetoothState(bool OnOff)
		{
			throw new NotImplementedException();
		}

		public void CheckBluetoothIsEnabled()
		{
			throw new NotImplementedException();
		}

		public void DiscoverBluetoothDevices()
		{
			throw new NotImplementedException();
		}
	}
}

