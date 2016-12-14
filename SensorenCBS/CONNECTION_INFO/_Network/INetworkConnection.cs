using System;
namespace SensorenCBS
{
	public interface INetworkConnection
	{
		bool IsConnected { get; }
		bool isMobile { get; }
		string ConnectionType { get; }
		string ExtraConnectionInfo { get; }
		string ConnectionStateInfo { get; }
		string ConnectionDetailStateInfo { get; }
		string MobileStrengthInfo { get; }
		
		//string ConnectionDetailStateInfo {

		void CheckNetworkConnection();
		void CheckNetworkConnectionType();
		void CheckExtraConnectionInfo();
		void CheckConnectionState();
		void CheckConnectionDetailState();
		void CheckMobileStrenght();
		
	}
}
