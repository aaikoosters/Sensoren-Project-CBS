using System;
using Android.App;
using Android.Content;
using Android.Net;
using Android.Telephony;
using SensorenCBS.Droid;
using Xamarin.Forms;
using Application = Android.App.Application;

[assembly: Dependency(typeof(NetworkConnection))]
namespace SensorenCBS.Droid
{
	public class NetworkConnection : INetworkConnection
	{
		ConnectivityManager connectivityManager;
		NetworkInfo activeNetworkInfo;

		public bool IsConnected { get; set; }
		public string ConnectionType { get; set; }
		public string ExtraConnectionInfo { get; set; }
		public string ConnectionStateInfo { get; set; }
		public string ConnectionDetailStateInfo { get; set; }

		public NetworkConnection()
		{
// <<<<<<< HEAD
// 			connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
// 			activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
// =======
// 			// Get the connectiviyManager (Android typical)
// 			// Get the network information, give the details about the current active network
// <<<<<<< HEAD
// 			//activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
// 			connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
//
// 			var requistroutetohost = connectivityManager.;
// =======
// 			activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
// 			activeNetworkInfo.GetDetailedState();
// 			activeNetworkInfo.GetState();
// >>>>>>> origin/WiFi
// >>>>>>> origin/WiFi
		}

		public void CheckNetworkConnection()
		{
			if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
			{
				IsConnected = true;
			}
			else {
				IsConnected = false;
			}
		}

		public void CheckNetworkConnectionType()
		{

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
			if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
			{
				ConnectionStateInfo = "Connection State information: " + activeNetworkInfo.GetState();
			}
			else {
				ConnectionStateInfo = "";
			}
		}

		public void CheckConnectionDetailState()
		{
			if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
			{
				ConnectionDetailStateInfo = "Detail Conn State information: " + activeNetworkInfo.GetDetailedState();
			}
			else {
				ConnectionDetailStateInfo = "";
			}
		}
	}
}
