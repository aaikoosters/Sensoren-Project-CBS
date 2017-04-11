using System.Collections.Generic;
using Xamarin.Forms;

namespace SensorenCBS
{
	public class Network
	{
		// connection to the interface
		INetworkConnection networkConnection = DependencyService.Get<INetworkConnection>();

		/**
		- calls the interfaceclass for native implementation,
			the first line in every function calls the interface for native
		- set boolean true (on) or false (off) for network is connected
		- return text connected or not connected
		*/
		public string connected()
		{
			networkConnection.CheckNetworkConnection();

			var networkConnected = networkConnection.IsConnected;
			var networkStatus = networkConnected ? "You are Connected" : "You are not Connected";
			return networkStatus;
		}
		
		// GET the connection type (mobile or wifi)
		public string connectionType()
		{
			networkConnection.CheckNetworkConnectionType();

			var networkConnType = networkConnection.ConnectionType;
			var networktype = networkConnType;
			return networktype;
		}

		// GET info, returns the SSID (network name)
		public string connectionExtraInfo()
		{
			networkConnection.CheckExtraConnectionInfo();

			var networkExtraInfo = networkConnection.ExtraConnectionInfo;
			var extraInfo = networkExtraInfo;
			return extraInfo;
		}
		
		// GET connection info (gives connected back, same info as connectionDetailStateInfo())
		public string connectionStateInfo()
		{
			networkConnection.CheckConnectionState();

			var networkStateInfo = networkConnection.ConnectionStateInfo;
			var stateInfo = networkStateInfo;
			return stateInfo;
		}

		// GET extra connection info (gives connected back)
		public string connectionDetailStateInfo()
		{
			networkConnection.CheckConnectionDetailState();

			var networkDetailStateInfo = networkConnection.ConnectionDetailStateInfo;
			var detailStateInfo = networkDetailStateInfo;
			return detailStateInfo;
		}
		
		// GET the network name
		public string getSSID()
		{
			return networkConnection.GetSSID();

		}
	}
}
