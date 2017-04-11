using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class NetworkPage : ContentPage
	{
		// variable 
		Network network;
		bool isConnected;
		string type;

		public NetworkPage()
		{
			InitializeComponent();
			// makes the connection to the netwerk class for implementation
			network = new Network();
			
			// wait function so there is time to fetch the connection information
			Device.StartTimer(new TimeSpan(0, 0, 2), () =>
			{
				isNetworkConnected();
				networkConnectionType();
				extraConnectionInfo();
				connectionState();
				// if the platform/device is from type iOS the SSID information will be fetched 
				if(Device.OS == TargetPlatform.iOS)
					getSSID();
				return false;
			});


		}
		
		// set the labels with the state infor 
		void connectionState()
		{
			lblConnState.Text = network.connectionStateInfo();
			lblConnDetailState.Text = network.connectionDetailStateInfo();
		}

		// check if you are connected, if so SET bool true
		// SET label tekst if connected 
		void isNetworkConnected()
		{
			
			lblStat.Text = network.connected();
			if (network.connected() == "You are Connected")
			{
				isConnected = true;
			}
			else { isConnected = false; }
		}

		// GET network type and SET label
		void networkConnectionType()
		{
			type = network.connectionType();
			lblconnType.Text = type;

		}

		// SET label to the ssid
		void getSSID()
		{
			var ssidback = network.getSSID();
			lblconnType.Text = ssidback;
		}

		// set label to extra connection info
		void extraConnectionInfo()
		{
			lblextConnInfo.Text = network.connectionExtraInfo();
		}

		// button action to open WifiPage
		void btnWifi(object s, EventArgs e)
		{
			Navigation.PushAsync(new WifiNetworkPage());
		}
	}
}
