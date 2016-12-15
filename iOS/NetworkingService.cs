using System;
using SensorenCBS.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(NetworkingService))]
namespace SensorenCBS.iOS
{
	public class NetworkingService : INetworking
	{
		public NetworkingService()
		{
		}

		public event EventHandler<INetworkingEventArgs> networkObtained;

		public void isConnected()
		{
			throw new NotImplementedException();
		}

		public void obtainNetworkInformation()
		{
			throw new NotImplementedException();
		}
	}
}
