using System;
using Xamarin.Forms;

namespace SensorenCBS
{
	public class Wifi
	{
		IWifiConnection wifiConnection = DependencyService.Get<IWifiConnection>();

		public Wifi()
		{
			
		}

		public string wifiSSID() {
			wifiConnection.CheckWifiSSID();
			return wifiConnection.WifiSSID;
		}
		public string wifiBSSID() {
			wifiConnection.CheckWifiBBSID();
			var bssid = wifiConnection.WifiBSSID;
			wifiConnection.bssids.Add(bssid);
			return bssid;
		}
		public int wifiFrequency() { wifiConnection.CheckWifiInformation(); return wifiConnection.WifiFrequency; }
		public int wifiLinkSpeed() { wifiConnection.CheckWifiInformation(); return wifiConnection.WifiLinkSpeed; }
		public int wifiIpAddress() { wifiConnection.CheckWifiInformation(); return wifiConnection.WifiIpAddress;}
		public string wifiMacAddress() { wifiConnection.CheckWifiInformation(); return wifiConnection.WifiMacAddress;}
		public int wifiNetworkId() { wifiConnection.CheckWifiInformation(); return wifiConnection.WifiNetworkId;}
		public int wifiRssi() { wifiConnection.CheckWifiInformation(); return wifiConnection.WifiRssi;}

	}
}
