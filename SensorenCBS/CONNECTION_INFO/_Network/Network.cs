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

			networkConnection.CheckNetworkConnection();
			networkConnection.CheckNetworkConnectionType();
		}

		public string connected()
		{
			networkConnected = networkConnection.IsConnected;
			var networkStatus = networkConnected ? "You are Connected" : "You are not Connected";
			return networkStatus;
		}

		public string connectionType()
		{
			networkConnType = networkConnection.ConnectionType;
			var networktype = networkConnType;
			return networktype;
		}

	}
}
