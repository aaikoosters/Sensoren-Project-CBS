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
		TelephonyManager telephonyManager;
		NetworkInfo activeNetworkInfo;
		GsmSignalStrengthListener signalStrengthListener;

		public bool IsConnected { get; set; }
		public bool isMobile { get; set; }
		public string mobileStrength { get; set; }
		public string ConnectionType { get; set; }
		public string ExtraConnectionInfo { get; set; }
		public string ConnectionStateInfo { get; set; }
		public string ConnectionDetailStateInfo { get; set; }
		public string MobileStrengthInfo { get; set; }


		public NetworkConnection()
		{
			// Get the connectiviyManager (Android typical)
			// Get the network information, give the details about the current active network
			//activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
		}

		public void CheckNetworkConnection()
		{
			// When the info is not null and it is connected or trying to connected you pass
			connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);

			activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
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
			connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);

			activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
			if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
			{
				var type = activeNetworkInfo.Type;
				ConnectionType = "Connection type: " + type;
			//	//if ( type == activeNetworkInfo.Type()
			//	{
					isMobile = true;
			//	}
			//}
			//else {
			//	ConnectionType = "";
			}
		}

		public void CheckMobileStrenght()
		{
			telephonyManager = (TelephonyManager)Application.Context.GetSystemService(Context.TelephonyService);
			signalStrengthListener = new GsmSignalStrengthListener();
			telephonyManager.Listen(signalStrengthListener, PhoneStateListenerFlags.SignalStrengths);
			signalStrengthListener.SignalStrengthChanged += HandleSignalStrenghtChanged;
		}

		void HandleSignalStrenghtChanged(int strength)
		{
			signalStrengthListener.SignalStrengthChanged -= HandleSignalStrenghtChanged;
			telephonyManager.Listen(signalStrengthListener, PhoneStateListenerFlags.None);
			mobileStrength = "GSM Signal strength: " + strength;
		}

		public void CheckExtraConnectionInfo()
		{
			// When the info is not null and it is connected or trying to connected you pass
			connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);

			activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
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
			connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);

			activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
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
			connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);

			activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
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
