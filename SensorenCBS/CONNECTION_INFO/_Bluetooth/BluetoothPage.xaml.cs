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

			if (lblStatText == "Bluetooth is Enabled")
			{
				btnBlueState.Text = "Turn Bluetooth off";
				stateOnOff = true;
			}
			else {
				btnBlueState.Text = "Turn Bluetooth on";
				stateOnOff = false;
			}
		}

		void btnConn(object s, EventArgs e)
		{
			if (stateOnOff)
			{
				btnBlueState.Text = "Turn Bluetooth off";
				lblStat.Text = "Bluetooth is Enabled";
			}
			else {
				btnBlueState.Text = "Turn Bluetooth on";
				lblStat.Text = "Bluetooth is Disabled";
				
			}
			bluetooth.changeState(stateOnOff);

		}

		//void btnBlueCon(object ob, EventArgs ea)
		//{
			
		//}
	}
}
