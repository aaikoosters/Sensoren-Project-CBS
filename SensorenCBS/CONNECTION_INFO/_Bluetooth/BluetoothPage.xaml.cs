using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class BluetoothPage : ContentPage
	{
		Bluetooth bluetooth = new Bluetooth();
		bool stateOnOff = false;


		public BluetoothPage()
		{
			InitializeComponent();
			isBluetoothEnabled();
		}

		void isBluetoothEnabled()
		{
			var lblStatText = bluetooth.isEnabled();
			lblStat.Text = lblStatText;
		}

		void btnConnOn(object s, EventArgs e)
		{
			bluetooth.changeState(true);
			InitializeComponent();
			isBluetoothEnabled();
		}

		void btnConnOff(object s, EventArgs e)
		{
			bluetooth.changeState(false);
			InitializeComponent();
			isBluetoothEnabled();
		}

		void btnDiscoverdBluetoothDevices(object s, EventArgs e)
		{
			var items = bluetooth.fetchDevices();
			listDevices.ItemsSource = items;

			//foreach (var dev in items)
			//{
			//	//var listViewItem = new ListViewItem(dev);


			//}
		}

		//void btnBlueCon(object ob, EventArgs ea)
		//{
			
		//}
	}
}
