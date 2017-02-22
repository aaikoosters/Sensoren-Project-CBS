using Android.Bluetooth;
using SensorenCBS.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(BluetoothConnection))]
namespace SensorenCBS.Droid
{
	public class BluetoothConnection : IBluetoothConnection
	{
		// The bluetooth implemenation with Android.Bluetooth
		BluetoothAdapter _bluetoothAdapter;
		// Implementation of IBluetoothConnection
		public bool isBluetoothOn { get; set; }
		public string bluetoothAddress { get; set; }
		public string bluetoothState { get; set; }
		public string bluetoothName { get; set; }
		public string bluetoothHashCode { get; set; }

		// Constructer where the _bluetoothAdapter is set to the DefaultAdapter
		public BluetoothConnection()
		{
			_bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
		}
		// Check if the bluetooth is enabled
		public void CheckBluetoothIsEnabled()
		{
			if (_bluetoothAdapter.IsEnabled)
			{
				isBluetoothOn = true;
			}
			else {
				isBluetoothOn = false;
			}
		}
		// method who can change the state of the bluetooth to on or off
		public void ChangeBluetoothState(bool OnOff)
		{
			if (OnOff) { _bluetoothAdapter.Enable(); }
			else { _bluetoothAdapter.Disable(); }
		}

		// combined method with bluetooth information from the device
		public void DiscoverBluetoothInformation()
		{
			bluetoothAddress = string.Format("Bluetooth address: {0}", _bluetoothAdapter.Address);
			bluetoothState = string.Format("Bluetooth is: {0}", _bluetoothAdapter.State);
			bluetoothName = string.Format("Bluetooth name: {0}", _bluetoothAdapter.Name);
		}

	}
}

