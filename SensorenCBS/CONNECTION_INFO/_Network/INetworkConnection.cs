using System;
namespace SensorenCBS
{
	public interface INetworkConnection
	{
		bool IsConnected { get; }
		string ConnectionType { get; }
		string ExtraConnectionInfo { get; }

		void CheckNetworkConnection();
		void CheckNetworkConnectionType();
		void CheckExtraConnectionInfo();
		void GetDetailState();
		void GetState();
	}
}
