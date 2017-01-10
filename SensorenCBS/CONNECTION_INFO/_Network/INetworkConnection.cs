using System;
using System.Collections.Generic;

namespace SensorenCBS
{
	public interface INetworkConnection
	{
		bool IsConnected { get; }
		string ConnectionType { get; }
		string ExtraConnectionInfo { get; }
		string ConnectionStateInfo { get; }
		string ConnectionDetailStateInfo { get; }
		List<string> AllNetworkSSID { get; }

		void CheckNetworkConnection();
		void CheckNetworkConnectionType();
		void CheckExtraConnectionInfo();
		void CheckConnectionState();
		void CheckConnectionDetailState();
		void CheckWifiPoints();
		

	}
}
