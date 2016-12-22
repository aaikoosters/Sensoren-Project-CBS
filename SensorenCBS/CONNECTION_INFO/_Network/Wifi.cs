using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace SensorenCBS
{
	public class Wifi
	{
		IWifiConnection wifiConnection = DependencyService.Get<IWifiConnection>();

		public string wifiSSID() { wifiConnection.CheckWifiSSID(); return wifiConnection.WifiSSID; }
		public string wifiBSSID() { wifiConnection.CheckWifiBBSID(); return wifiConnection.WifiBSSID; }
		public int wifiFrequency() { wifiConnection.CheckWifiInformation(); return wifiConnection.WifiFrequency; }
		public int wifiLinkSpeed() { wifiConnection.CheckWifiInformation(); return wifiConnection.WifiLinkSpeed; }
		public string wifiIpAddress() { wifiConnection.CheckWifiInformation(); return wifiConnection.WifiIpAddress;}
		public string wifiMacAddress() { wifiConnection.CheckWifiInformation(); return wifiConnection.WifiMacAddress;}
		public int wifiNetworkId() { wifiConnection.CheckWifiInformation(); return wifiConnection.WifiNetworkId;}
		public int wifiRssi() { wifiConnection.CheckWifiInformation(); return wifiConnection.WifiRssi; }
		public List<string> wifiAllBSSID() { wifiConnection.CheckAllWifiBSSID(); return wifiConnection.AllWifiBssids; }

	}
}
