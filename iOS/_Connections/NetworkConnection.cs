﻿using System;
using System.Net;
using SystemConfiguration;
using CoreFoundation;
using Xamarin.Forms;
//using SensorenCBS.iOS;
using System.Collections.Generic;
using SensorenCBS.iOS;
using Foundation;

[assembly: Dependency(typeof(NetworkConnection))]
namespace SensorenCBS.iOS
{
	public class NetworkConnection : INetworkConnection
	{

		public string ConnectionType { get; set; }
		public string ExtraConnectionInfo { get; set; }
		public string ConnectionStateInfo { get; set; }
		public string ConnectionDetailStateInfo { get; set; }

		public bool IsConnected
		{
			get; set;
		}

		/*        public NetworkConnection()
				{
					InternetConnectionStatus();
					}*/
		//public bool IsConnected { get; set; }
		public void CheckNetworkConnection()
		{
			InternetConnectionStatus();
		}

		private void UpdateNetworkStatus()
		{
			if (InternetConnectionStatus())
			{
				IsConnected = true;
			}
			else if (LocalWifiConnectionStatus())
			{
				IsConnected = true;
			}
			else
			{
				IsConnected = false;
			}
		}

		private event EventHandler ReachabilityChanged;
		private void OnChange(NetworkReachabilityFlags flags)
		{
			var h = ReachabilityChanged;
			if (h != null)
				h(null, EventArgs.Empty);
		}

		private NetworkReachability defaultRouteReachability;
		private bool IsNetworkAvailable(out NetworkReachabilityFlags flags)
		{
			if (defaultRouteReachability == null)
			{
				defaultRouteReachability = new NetworkReachability(new IPAddress(0));
				defaultRouteReachability.SetNotification(OnChange);
				defaultRouteReachability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
			}
			if (!defaultRouteReachability.TryGetFlags(out flags))
				return false;
			return IsReachableWithoutRequiringConnection(flags);
		}

		private NetworkReachability adHocWiFiNetworkReachability;
		private bool IsAdHocWiFiNetworkAvailable(out NetworkReachabilityFlags flags)
		{
			if (adHocWiFiNetworkReachability == null)
			{
				adHocWiFiNetworkReachability = new NetworkReachability(new IPAddress(new byte[] { 169, 254, 0, 0 }));
				adHocWiFiNetworkReachability.SetNotification(OnChange);
				adHocWiFiNetworkReachability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
			}

			if (!adHocWiFiNetworkReachability.TryGetFlags(out flags))
				return false;

			return IsReachableWithoutRequiringConnection(flags);
		}

		public static bool IsReachableWithoutRequiringConnection(NetworkReachabilityFlags flags)
		{
			// Is it reachable with the current network configuration?
			bool isReachable = (flags & NetworkReachabilityFlags.Reachable) != 0;

			// Do we need a connection to reach it?
			bool noConnectionRequired = (flags & NetworkReachabilityFlags.ConnectionRequired) == 0;

			// Since the network stack will automatically try to get the WAN up,
			// probe that
			if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
				noConnectionRequired = true;

			return isReachable && noConnectionRequired;
		}

		private bool InternetConnectionStatus()
		{
			NetworkReachabilityFlags flags;
			bool defaultNetworkAvailable = IsNetworkAvailable(out flags);
			if (defaultNetworkAvailable && ((flags & NetworkReachabilityFlags.IsDirect) != 0))
			{
				return false;
			}
			else if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
			{
				return true;
			}
			else if (flags == 0)
			{
				return false;
			}

			return true;
		}

		private bool LocalWifiConnectionStatus()
		{
			NetworkReachabilityFlags flags;
			if (IsAdHocWiFiNetworkAvailable(out flags))
			{
				if ((flags & NetworkReachabilityFlags.IsDirect) != 0)
					return true;
			}
			return false;
		}

		public string GetSSID()
		{
			bool withMacAddress = true;
			try
			{
				NSDictionary dict;
				var status = CaptiveNetwork.TryCopyCurrentNetworkInfo("en0", out dict);

				if (status == StatusCode.NoKey)
					return "";

				var bssid = dict[CaptiveNetwork.NetworkInfoKeyBSSID];
				var ssid = dict[CaptiveNetwork.NetworkInfoKeySSID];
				var ssidD = dict[CaptiveNetwork.NetworkInfoKeySSIDData];
				//var ssiddat = dict [CaptiveNetwork.NetworkInfoKeySSIDData];

				if (withMacAddress)
					return ssid + ", " + bssid+ ", " + ssidD;
				return ssid.ToString();


				//foreach (string intf in CaptiveNetwork.GetSupportedInterfaces()) {
				//NSDictionary dict2;
				//CaptiveNetwork.TryCopyCurrentNetworkInfo (intf, out dict2);

				////if (status == StatusCode.NoKey)
				////	return "";

				//var bssid2 = dict [CaptiveNetwork.NetworkInfoKeyBSSID];
				//var ssid2 = dict [CaptiveNetwork.NetworkInfoKeySSID];
				//var ssiddat2 = dict [CaptiveNetwork.NetworkInfoKeySSIDData];
				//}
			
			}
			catch
			{
				return "";
			}
		}


		public void CheckNetworkConnectionType()
		{
			//throw new NotImplementedException();
		}

		public void CheckExtraConnectionInfo()
		{
			//throw new NotImplementedException();
		}

		public void CheckConnectionState()
		{
			//throw new NotImplementedException();
		}

		public void CheckConnectionDetailState()
		{
			//throw new NotImplementedException();
		}
	}
}
