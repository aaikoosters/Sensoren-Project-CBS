using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class NetworkPage : ContentPage
	{
		Network network;
		bool isConnected;
		string type;

		public NetworkPage()
		{
			InitializeComponent();
			network = new Network();

			Device.StartTimer(new TimeSpan(0, 0, 2), () =>
			{
				isNetworkConnected();
				networkConnectionType();
				extraConnectionInfo();
				connectionState();
				return false;
			});


		}

		void availebleNetwork()
		{
			var networks = network.availebleWifiConnections();
			foreach (var n in networks)
			{
				listAvailable.ItemsSource = n;
			}
			//listAvailable.ItemsSource
		}

		void connectionState()
		{
			lblConnState.Text = network.connectionStateInfo();
			lblConnDetailState.Text = network.connectionDetailStateInfo();
		}

		void isNetworkConnected()
		{
			
			lblStat.Text = network.connected();
			if (network.connected() == "You are Connected")
			{
				isConnected = true;
			}
			else { isConnected = false; }
		}

		void networkConnectionType()
		{
			type = network.connectionType();
			lblconnType.Text = type;

		}

		void extraConnectionInfo()
		{
			lblextConnInfo.Text = network.connectionExtraInfo();
		}

		void btnWifi(object s, EventArgs e)
		{
			Navigation.PushAsync(new WifiNetworkPage());
		}
	}
}
