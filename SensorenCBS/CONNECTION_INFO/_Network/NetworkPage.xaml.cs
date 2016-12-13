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
			isNetworkConnected();
			networkConnectionType();
		}

		void isNetworkConnected()
		{
			lblStat.Text = network.connected();
		}

		void networkConnectionType()
		{
			lblconnType.Text = network.connectionType();
		}
	}
}
