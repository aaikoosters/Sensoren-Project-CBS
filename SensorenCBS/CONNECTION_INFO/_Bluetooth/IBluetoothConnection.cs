namespace SensorenCBS
{
	public interface IBluetoothConnection
	{
		bool isBluetoothOn { get; }
		string bluetoothAddress { get; }

		string bluetoothState { get; }
		string bluetoothName { get; }

		void CheckBluetoothIsEnabled();
		void ChangeBluetoothState(bool OnOff);
		void DiscoverBluetoothInformation();

	}

}

