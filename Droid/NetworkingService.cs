using System;
using Android.Content;
using Android.Net;
using Xamarin.Forms;
using Application = Android.App.Application;
using SensorenCBS.Droid;

[assembly: Dependency(typeof(NetworkingService))]
namespace SensorenCBS.Droid
{
	public class NetworkEventArgs : EventArgs, INetworkingEventArgs
	{
		public bool isConnected { get; set; }
		public string connectionType { get; set; }
	}


	public class NetworkingService : INetworking
	{
		bool isOnline;
		string connType;

		public NetworkingService()
		{
		}

		public event EventHandler<INetworkingEventArgs> networkObtained;

		public void OnNetwork(string connType, bool connected)
		{
			NetworkEventArgs args = new NetworkEventArgs();
			args.connectionType = connType;
			args.isConnected = connected; 
		}

		event EventHandler<INetworkingEventArgs> INetworking.networkObtained
		{
			add { networkObtained += value; }
			remove { networkObtained -= value; }
		}

		public void obtainNetworkInformation()
		{
			var conn = isOnline;
			var type = connType;
			OnNetwork(type, conn);
		}


		private void DetectNetwork()
		{
			//var context = Android.App.Application.Context;
			var connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
			var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;


			//var connectivityManager = (ConnectivityManager)context.GetSystemService(context.ConnectivityService);
			isOnline = (activeNetworkInfo != null) && activeNetworkInfo.IsConnected;
			//Log.Debug(TAG, "IsOnline = {0}", isOnline);

			if (isOnline)
			{
				//_isConnectedImage.SetImageResource(Resource.Drawable.green_square);

				// Display the type of connection
				NetworkInfo.State activeState = activeNetworkInfo.GetState();
				connType = activeNetworkInfo.TypeName;

				//// Check for a WiFi connection
				//NetworkInfo wifiInfo = connectivityManager.GetNetworkInfo(ConnectivityType.Wifi);
				//if (wifiInfo.IsConnected)
				//{
				//	Log.Debug(TAG, "Wifi connected.");
				//	_wifiImage.SetImageResource(Resource.Drawable.green_square);
				//}
				//else
				//{
				//	Log.Debug(TAG, "Wifi disconnected.");
				//	_wifiImage.SetImageResource(Resource.Drawable.red_square);
				//}

				//// Check if roaming
				//NetworkInfo mobileInfo = connectivityManager.GetNetworkInfo(ConnectivityType.Mobile);
				//if (mobileInfo.IsRoaming && mobileInfo.IsConnected)
				//{
				//	Log.Debug(TAG, "Roaming.");
				//	_roamingImage.SetImageResource(Resource.Drawable.green_square);
				//}
				//else
				//{
				//	Log.Debug(TAG, "Not roaming.");
				//	_roamingImage.SetImageResource(Resource.Drawable.red_square);
				//}
			}
			else
			{
				//_isConnectedImage.SetImageResource(Resource.Drawable.red_square);
				//_wifiImage.SetImageResource(Resource.Drawable.red_square);
				//_roamingImage.SetImageResource(Resource.Drawable.red_square);
				isOnline = false;
				connType = "N/A";
			}
		}


		public void isConnected()
		{
			throw new NotImplementedException();
		}

	}
}
