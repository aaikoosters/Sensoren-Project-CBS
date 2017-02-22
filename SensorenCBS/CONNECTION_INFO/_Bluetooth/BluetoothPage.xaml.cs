using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;
using Plugin.BLE;
using Xamarin.Forms;
using Plugin.BLE.Abstractions.Extensions;
using Plugin.BLE.Abstractions.Contracts;

namespace SensorenCBS
{
	public partial class BluetoothPage : ContentPage
	{
		//Bluetooth _bluetooth = new Bluetooth();
		IBluetoothLE _ble;
		IAdapter _adapter;
		IDevice devics;
		List<string> _deviceList;
		List<IDevice> deviceList = new List<IDevice>();
		


		public BluetoothPage()
		{
			InitializeComponent();
			_ble = CrossBluetoothLE.Current;
			_adapter = CrossBluetoothLE.Current.Adapter;



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
				lblState.Text = "Bluetooth is: " + e.NewState.ToString();
			};
			lblState.Text = "Bluetooth is: " + state.ToString();
			foreach (var i in deviceList){
				Debug.WriteLine("Deviec in in list: " + i);
			}

		}


		void scanForDevices()
		{
			var device = _adapter.DiscoverDeviceAsync(dev => dev.Name.Equals("Aaik"));
		}

	}
}
