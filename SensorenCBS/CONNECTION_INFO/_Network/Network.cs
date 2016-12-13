using System;
using Xamarin.Forms;

namespace SensorenCBS
{
	public class Network
	{
		INetworkConnection networkConnection; 
		public Network()
		{
			networkConnection = DependencyService.Get<INetworkConnection>();
		}

		public string connected()
		{
			networkConnection.CheckNetworkConnection();
			var networkStatus = networkConnection.IsConnected ? "You are Connected" : "You are not Connected";
			return networkStatus;

		}
	}
}
