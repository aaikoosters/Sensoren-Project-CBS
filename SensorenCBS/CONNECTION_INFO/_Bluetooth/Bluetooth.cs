using Xamarin.Forms;

namespace SensorenCBS
{
	public class Bluetooth
	{
		// connection to the interface
		IBluetoothConnection bluetoothConnection = DependencyService.Get<IBluetoothConnection>();

		public Bluetooth()
		{
		}

		/**
		- calls the interfaceclass for native implementation,
			the first line in every function calls the interface for native
		- set boolean true (on) or false (off) for bluetooth is Enabled 
		- return text enabled or disabled
		*/
		public string isEnabled()
		{
			bluetoothConnection.CheckBluetoothIsEnabled();
			var bluetoothEnabled = bluetoothConnection.isBluetoothOn;
			return bluetoothEnabled ? "Bluetooth is Enabled" : "Bluetooth is Disabled";
		}
		
		// Set bluetooth on or off
		public void changeState(bool change)
		{
			bluetoothConnection.ChangeBluetoothState(change);
		}

		// get the bluetoothAdress
		public string bluetoothAddress()
		{
			bluetoothConnection.DiscoverBluetoothInformation();
			return bluetoothConnection.bluetoothAddress;
		}

		// get the state, same as the furst function
		public string bluetoothState()
		{
			return bluetoothConnection.bluetoothState;
		}
		
		// get the bluetooth name
		public string bluetoothName()
		{
			bluetoothConnection.DiscoverBluetoothInformation();
			return bluetoothConnection.bluetoothName;
		}
	}
}
