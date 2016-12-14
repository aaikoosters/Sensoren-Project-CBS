using System;
namespace SensorenCBS
{
	public interface INetworkConnection
	{
		bool IsConnected { get; }
		string ConnectionType { get; }
		string ExtraConnectionInfo { get; }
		string ConnectionStateInfo { get; }
		string ConnectionDetailStateInfo { get; }
		
		//string ConnectionDetailStateInfo {

		void CheckNetworkConnection();
		void CheckNetworkConnectionType();
		void CheckExtraConnectionInfo();
<<<<<<< HEAD
		void CheckConnectionState();
		void CheckConnectionDetailState();
		
=======
		void GetDetailState();
		void GetState();
>>>>>>> origin/WiFi
	}
}
