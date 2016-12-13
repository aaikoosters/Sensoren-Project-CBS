using System;

namespace SensorenCBS
{
	public interface INetworking
	{
		//void ipAdress();
		void obtainNetworkInformation();
		event EventHandler<INetworkingEventArgs> networkObtained;
	}
	public interface INetworkingEventArgs
	{
		bool isConnected { get; set;}
		string connectionType { get; set;}
	}
}
