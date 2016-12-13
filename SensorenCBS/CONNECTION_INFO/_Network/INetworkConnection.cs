using System;
namespace SensorenCBS
{
	public interface INetworkConnection
	{
		bool IsConnected { get; }
		string ConnectionType { get; }
		void CheckNetworkConnection();
		void CheckNetworkConnectionType();
		
	}
}
