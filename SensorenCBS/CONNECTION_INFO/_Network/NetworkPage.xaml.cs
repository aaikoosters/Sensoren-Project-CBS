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
		}

		void isNetworkConnected()
		{
			lblStat.Text = network.connected();
		}
}
}
