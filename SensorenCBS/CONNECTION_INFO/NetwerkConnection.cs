using System;
using Xamarin.Forms;

namespace SensorenCBS
{
	public class NetwerkConnection
	{
		public NetwerkConnection()
		{
		}

		public bool conncected()
		{
			var networkConnection = DependencyService.Get<INetworking>();
			networkConnection.CheckNetworkConnection();
			var 
			return true;
		}
	}
}
