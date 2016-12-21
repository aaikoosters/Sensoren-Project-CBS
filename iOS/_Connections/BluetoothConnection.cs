using System;
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

		public string bluetoothAddress
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public string bluetoothName
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public string bluetoothState
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public Array discoverdBluetDevices
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool isBluetoothOn { get; set; }

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

		public void DiscoverBluetoothInformation()
		{
			throw new NotImplementedException();
		}
	}
}

