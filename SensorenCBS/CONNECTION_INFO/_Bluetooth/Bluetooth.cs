using Xamarin.Forms;

namespace SensorenCBS
{
	public class Bluetooth
	{
		IBluetoothConnection bluetoothConnection = DependencyService.Get<IBluetoothConnection>();

		public Bluetooth()
		{
		}

		public string isEnabled()
		{
			bluetoothConnection.CheckBluetoothIsEnabled();
			var bluetoothEnabled = bluetoothConnection.isBluetoothOn;
			return bluetoothEnabled ? "Bluetooth is Enabled" : "Bluetooth is Disabled";
		}

		public void changeState(bool change)
		{
			bluetoothConnection.ChangeBluetoothState(change);
		}

		public string bluetoothAddress()
		{
			bluetoothConnection.DiscoverBluetoothInformation();
			return bluetoothConnection.bluetoothAddress;
		}

		public string bluetoothState()
		{
			bluetoothConnection.DiscoverBluetoothInformation();
			return bluetoothConnection.bluetoothState;
		}

		public string bluetoothName()
		{
			bluetoothConnection.DiscoverBluetoothInformation();
			return bluetoothConnection.bluetoothName;
		}
	}
}
