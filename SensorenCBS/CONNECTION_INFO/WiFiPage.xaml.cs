using System;
using System.Collections.Generic;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class WiFiPage : ContentPage
	{
		INetworking inetworking = DependencyService.Get<INetworking>();

		public WiFiPage()
		{
			getInformation();
		}

		void getInformation()
		{
			inetworking.networkObtained += (object sender, INetworkingEventArgs e) =>
			{
				var connected = e.isConnected;
				var connType = e.connectionType;
				lblGyro.Text = "Conn: " + connected + "; Type: " + connType;
			};
			inetworking.obtainNetworkInformation();
		}
}
}
