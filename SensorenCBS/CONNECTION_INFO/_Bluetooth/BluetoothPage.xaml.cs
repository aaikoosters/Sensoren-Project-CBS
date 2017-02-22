using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;
using Plugin.BLE;
using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class BluetoothPage : ContentPage
	{
		//Bluetooth _bluetooth = new Bluetooth();
		Plugin.BLE.Abstractions.Contracts.IBluetoothLE _ble;
		Plugin.BLE.Abstractions.Contracts.IAdapter _adapter;
		List<string> _deviceList;


		public BluetoothPage()
		{
			InitializeComponent();
			_ble = CrossBluetoothLE.Current;
			_adapter = CrossBluetoothLE.Current.Adapter;
			_deviceList = new List<string>();
					
		}


		void btnState(object s, EventArgs e) { StateOrChanged(); }
		void btnScan(object s, EventArgs e) { scanForDevices(); }
		void btnServices(object s, EventArgs e) { services(); }

		async void services()
		{
			
		}

		void StateOrChanged()
		{
			var state = _ble.State;
			_ble.StateChanged += (sender, e) =>
			{
				Debug.WriteLine($"The bluetooth state changed to {e.NewState}");
				lblState.Text = state.ToString();
			};
			lblState.Text = state.ToString();

		}


		void scanForDevices()
		{
			_adapter.StartScanningForDevicesAsync();
		
			//await _adapter.StartScanningForDevicesAsync();
			
			//_adapter.DeviceDiscovered += (s, a) =>
			//{
			//	_deviceList.Add(a.Device.ToString());
			//	Debug.WriteLine($"The bluetooth discoverd {a.Device}");


			//};

		}

	}
}
