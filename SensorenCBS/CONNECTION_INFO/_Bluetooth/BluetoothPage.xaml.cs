using System;
using System.Collections.Generic;
using System.Diagnostics;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.Extensions;
using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class BluetoothPage : ContentPage
	{
		//Bluetooth _bluetooth = new Bluetooth();
		IBluetoothLE _ble;
		IAdapter _adapter;
		IDevice _devices;
		List<IDevice> _deviceList = new List<IDevice>();



		public BluetoothPage()
		{
			InitializeComponent();
			_ble = CrossBluetoothLE.Current;
			_adapter = CrossBluetoothLE.Current.Adapter;



		}


		void btnState(object s, EventArgs e) { StateOrChanged(); }

		void btnScan(object s, EventArgs e)
		{
			scanForDevices();
		}
		void btnServices(object s, EventArgs e) { StateOrChanged(); }

		async void services()
		{

		}

		void StateOrChanged()
		{
			var state = _ble.State;
			var name = _adapter.
			_ble.StateChanged += (sender, e) =>
			{
				Debug.WriteLine($"The bluetooth state changed to {e.NewState}");
				lblState.Text = "Bluetooth is: " + e.NewState.ToString();
			};
			lblState.Text = "Bluetooth is: " + state.ToString();
			foreach (var i in _deviceList)
			{
				Debug.WriteLine("Deviec in in list: " + i);
			}

		}

		//public static async Task<IDevice> DiscoverDeviceAsync(this IAdapter adapter, Func<IDevice, bool> deviceFilter, CancellationToken cancellationToken = default(CancellationToken))
		//{
		//	var device = adapter.DiscoveredDevices.FirstOrDefault(deviceFilter);
		//	if (device != null)
		//	{
		//		return device;
		//	}

		//	if (adapter.IsScanning)
		//	{
		//		await adapter.StopScanningForDevicesAsync();
		//	}

		//	return await TaskBuilder.FromEvent<IDevice, EventHandler<DeviceEventArgs>, EventHandler>(
		//		execute: () => adapter.StartScanningForDevicesAsync(deviceFilter, cancellationToken),

		//		getCompleteHandler: (complete, reject) => ((sender, args) =>
		//		{
		//			complete(args.Device);
		//			adapter.StopScanningForDevicesAsync();
		//		}),
		//		subscribeComplete: handler => adapter.DeviceDiscovered += handler,
		//		unsubscribeComplete: handler => adapter.DeviceDiscovered -= handler,

		//		getRejectHandler: reject => ((sender, args) => { reject(new DeviceDiscoverException()); }),
		//		subscribeReject: handler => adapter.ScanTimeoutElapsed += handler,
		//		unsubscribeReject: handler => adapter.ScanTimeoutElapsed -= handler,

		//		token: cancellationToken);
		//}



		async void scanForDevices()
		{
			//_adapter.DeviceDiscovered += (s, a) => _deviceList.Add(a.Device);
			//await _adapter.StartScanningForDevicesAsync();

			var device = _adapter.DiscoverDeviceAsync(dev => dev.Name.Equals("Aaik"));
			var iets = device.GetType();
			Debug.WriteLine("TYPE not founded: " + iets);



			//try
			//{
			//	await _adapter.ConnectToDeviceAsync((IDevice)device);
			//}
			//catch (DeviceConnectionException e)
			//{
			//	// ... could not connect to device
			//	Debug.WriteLine("Device not founded: " + e);

			//}
		}

	}
}
