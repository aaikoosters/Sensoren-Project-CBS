﻿using System;
using Xamarin.Forms;

namespace SensorenCBS
{
	public class Network
	{
		INetworkConnection networkConnection = DependencyService.Get<INetworkConnection>();
		//INetworkConnection ;

		public Network()
		{

		}

		public string connected()
		{
			networkConnection.CheckNetworkConnection();
			
			var networkConnected = networkConnection.IsConnected;
			var networkStatus = networkConnected ? "You are Connected" : "You are not Connected";
			return networkStatus;
		}

		public string connectionType()
		{
			networkConnection.CheckNetworkConnectionType();
			
			var networkConnType = networkConnection.ConnectionType;
			var networktype = networkConnType;
			return networktype;
		}

		public string connectionExtraInfo()
		{
			networkConnection.CheckExtraConnectionInfo();
			
			var networkExtraInfo = networkConnection.ExtraConnectionInfo;
			var extraInfo = networkExtraInfo;
			return extraInfo;
		}

	}
}
