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

		public string bluetoothAddress { get; set; }
		public string bluetoothName { get; set; }
		public string bluetoothState { get; set; }
		public bool isBluetoothOn { get; set; }


		public void ChangeBluetoothState(bool OnOff)
		{
			throw new NotImplementedException();
		}

		public void CheckBluetoothIsEnabled()
		{
			throw new NotImplementedException();
		}

		public void DiscoverBluetoothInformation()
		{
			throw new NotImplementedException();
		}
	}

}