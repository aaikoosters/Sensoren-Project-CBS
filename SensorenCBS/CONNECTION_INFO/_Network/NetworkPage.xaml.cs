using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class NetworkPage : ContentPage
	{
		Network network;
		//bool isConnected;
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
				if(Device.OS == TargetPlatform.iOS)
					getSSID();
				return false;
			});


		}

		void connectionState()
		{
			lblConnState.Text = network.connectionStateInfo();
			lblConnDetailState.Text = network.connectionDetailStateInfo();
		}

		void isNetworkConnected()
		{
			
			lblStat.Text = network.connected();
		}

		void networkConnectionType()
		{
			type = network.connectionType();
			lblconnType.Text = type;

		}

		void getSSID()
		{
			var ssidback = network.getSSID();
			lblconnType.Text = ssidback;
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
