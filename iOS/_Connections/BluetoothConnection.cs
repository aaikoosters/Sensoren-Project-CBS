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

		public Array discoverdBluetDevices
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool isBluetoothOn { get; set; }

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

