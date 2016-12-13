using System;
using Android.App;
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
		ConnectivityManager connectivityManager;
		NetworkInfo activeNetworkInfo;
		public NetworkConnection()
		{
			// Get the connectiviyManager (Android typical)
			connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
			// Get the network information, give the details about the current active network
			activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
		}

		public bool IsConnected { get; set; }
		public string ConnectionType { get; set;}

		public void CheckNetwork()
		{
			// When the info is not null and it is connected or trying to connected you pass
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
			
			// When the info is not null and it is connected or trying to connected you pass
			if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
			{
				ConnectionType = "Connection type: " + activeNetworkInfo.Type;
			}
			else {
				ConnectionType = "There isn't a connection";
			}
		}
	}
}
