using System;
using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class NetworkPage : ContentPage
	{
		Network _network;

		public NetworkPage()
		{
			InitializeComponent();
			_network = new Network();


			if (Device.OS == TargetPlatform.iOS)
			{
				Device.StartTimer(new TimeSpan(0, 0, 2), () =>
				{
					getSSID();
					return false;
				});

				lblConnState.IsVisible = false;
				lblConnDetailState.IsVisible = false;
				//lblStat.IsVisible = false;
				lblconnType.IsVisible = false;
				lblextConnInfo.IsVisible = false;
				btnWifi.IsVisible = false;


			}
			else { 
				Device.StartTimer(new TimeSpan(0, 0, 2), () =>
				{
					connectionInformation();
					return false;
				});
			}

		}

		void connectionInformation()
		{
			lblConnState.Text = _network.connectionStateInfo();
			lblConnDetailState.Text = _network.connectionDetailStateInfo();
			lblStat.Text = _network.connected();
			lblconnType.Text = _network.connectionType();
			lblextConnInfo.Text = _network.connectionExtraInfo();
		}

		void getSSID()
		{
			var ssidback = _network.getSSID();
			lblStat.Text = ssidback;
		}

		void btnWifiClicked(object s, EventArgs e)
		{
			Navigation.PushAsync(new WifiNetworkPage());
		}
	}
}
