using System;
using Xamarin.Forms;

namespace SensorenCBS
{
	public class Network
	{
		INetworkConnection networkConnection;
		bool networkConnected;
		string networkConnType;

		public Network()
		{
			networkConnection = DependencyService.Get<INetworkConnection>();
			networkConnected = networkConnection.IsConnected;
			networkConnType = networkConnection.ConnectionType;

		}

		public string connected()
		{
			networkConnection.CheckNetworkConnection();
			var networkStatus = networkConnected ? "You are Connected" : "You are not Connected";
			return networkStatus;

		}

		public string connectionType()
		{
			networkConnection.CheckNetworkConnectionType();
			var networkType = "Not known";
			if (networkConnected)
			{
				return networkType = networkConnType;
			}
			else {

				return networkType;
			}
		}

	}
}
