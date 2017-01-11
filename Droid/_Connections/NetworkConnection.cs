using System.Collections.Generic;
using Android.Content;
using Android.Net;
using SensorenCBS.Droid;
using Xamarin.Forms;
using Application = Android.App.Application;

[assembly: Dependency(typeof(NetworkConnection))]
namespace SensorenCBS.Droid
{
	public class NetworkConnection : INetworkConnection
	{
		// ConnectivivtyManager and NetworkInfo are the assembly implementations
		// imported with Android.Net
		ConnectivityManager connectivityManager;
		NetworkInfo activeNetworkInfo;
		//Inheritance from INetworkConnection
		public bool IsConnected { get; set; }
		public string ConnectionType { get; set; }
		public string ExtraConnectionInfo { get; set; }
		public string ConnectionStateInfo { get; set; }
		public string ConnectionDetailStateInfo { get; set; }
		// Constructor where connectivityManager and activeNetworkInfo one times is setted
		public NetworkConnection()
		{
			connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
			activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
			CheckNetworkConnection();
			//wifiInfo = connectivityManager.
		}
		// if there is a connection wifi or mobile network
		public void CheckNetworkConnection()
		{ 
			// check if there is network info if yes than there is a connecton
			if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
			{
				IsConnected = true;
			}
			else {
				IsConnected = false;
			}
		}
		// check the connected type 
		public void CheckNetworkConnectionType()
		{
			// Mobile or Wifi
			if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
			{
				ConnectionType = "Connection type: " + activeNetworkInfo.Type;
			}
			else {
				ConnectionType = "";
			}
		}

		public void CheckExtraConnectionInfo()
		{
			// displays the SSID name of the network
			if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
			{
				ExtraConnectionInfo = "Extra connection information: " + activeNetworkInfo.ExtraInfo;
			}
			else {
				ExtraConnectionInfo = "";
			}
		}


		public void CheckConnectionState()
		{
			// Gives the state of the connection
			if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting){
				ConnectionStateInfo = "Connection State information: " + activeNetworkInfo.GetState();
			}
			else {
				ConnectionStateInfo = "";
			}
		}

		public void CheckConnectionDetailState()
		{
			// Gives the detailed state of the connection
			if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting){
				ConnectionDetailStateInfo = "Detail Conn State information: " + activeNetworkInfo.GetDetailedState();
			}
			else {
				ConnectionDetailStateInfo = "";
			}
		}
	}
}
