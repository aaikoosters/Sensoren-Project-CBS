using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class NetworkPage : ContentPage
	{
		Network network = new Network();

		public NetworkPage()
		{
			InitializeComponent();
			Device.StartTimer(new TimeSpan(0, 0, 2), () =>
			{
				isNetworkConnected();
				networkConnectionType();
				extraConnectionInfo();
				return false;
			});

		}

		void isNetworkConnected()
		{
			lblStat.Text = network.connected();
		}

		void networkConnectionType()
		{
			lblconnType.Text = network.connectionType();
		}

		void extraConnectionInfo()
		{
			lblextConnInfo.Text = network.connectionExtraInfo();
		}
	}
}
