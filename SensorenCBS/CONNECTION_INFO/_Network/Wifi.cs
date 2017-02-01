using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SensorenCBS
{
	public class Wifi
	{
		IWifiConnection _wifiConnection = DependencyService.Get<IWifiConnection>();

		public string wifiSSID() { _wifiConnection.CheckWifiSSID(); return _wifiConnection.WifiSSID;}
		public string wifiBSSID() { _wifiConnection.CheckWifiBBSID(); return _wifiConnection.WifiBSSID; }
		public int wifiFrequency() { _wifiConnection.CheckWifiInformation(); return _wifiConnection.WifiFrequency; }
		public int wifiLinkSpeed() { _wifiConnection.CheckWifiInformation(); return _wifiConnection.WifiLinkSpeed; }
		public string wifiIpAddress() { _wifiConnection.CheckWifiInformation(); return _wifiConnection.WifiIpAddress; }
		public string wifiMacAddress() { _wifiConnection.CheckWifiInformation(); return _wifiConnection.WifiMacAddress; }
		public int wifiNetworkId() { _wifiConnection.CheckWifiInformation(); return _wifiConnection.WifiNetworkId; }
		public int wifiRssi() { _wifiConnection.CheckWifiInformation(); return _wifiConnection.WifiRssi; }
		public List<string> wifiAllBSSID() { _wifiConnection.CheckAllWifiBSSID(); return _wifiConnection.AllWifiBssids; }

		public void FetchNearbyWifi(DateTime time)
		{
			//// call the native function
			//_wifiConnection.FetchNearbyWifi(); 
			_wifiConnection.FetchNearbyWifi(time);
			//_wifiConnection.
			//return _wifiConnection.NearbyWifiList; 
		}
	}
}