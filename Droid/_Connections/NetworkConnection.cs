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
		public NetworkConnection()
		{
		}

		public bool IsConnected { get; set; }

		public void CheckNetworkConnection()
		{
			// Get the connectiviyManager (Android typical)
			var connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
			// Get the network information, give the details about the current active network
			var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
			// When the info is not null and it is connected or trying to connected you pass
			if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
			{
				IsConnected = true;
			}
			else {
				IsConnected = false;
			}

		}
	}
}
