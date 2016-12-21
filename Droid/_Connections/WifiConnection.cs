using System;
using Android.Content;
using Android.Net.Wifi;
using SensorenCBS.Droid;
using Xamarin.Forms;
using Application = Android.App.Application;


[assembly: Dependency(typeof(WifiConnection))]
namespace SensorenCBS.Droid
{
	public class WifiConnection : IWifiConnection
	{
		WifiManager wifiManager;
		WifiInfo wifiInfo;

		public string WifiSSID { get; set; }
		public string WifiBSSID { get; set; }
		public int WifiFrequency { get; set; }
		public int WifiLinkSpeed { get; set; }
		public int WifiIpAddress { get; set; }
		public string WifiMacAddress { get; set; }
		public int WifiNetworkId { get; set; }
		public int WifiRssi { get; set; }
		public string WifiRssiLevel { get; set; }

		public WifiConnection()
		{
			wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
			wifiInfo = wifiManager.ConnectionInfo;
		}

		public void CheckWifiSSID()
		{
			WifiSSID = wifiInfo.SSID + ", " + wifiInfo.HiddenSSID;
		}

		public void CheckWifiBBSID()
		{
			WifiBSSID = wifiInfo.BSSID;
		}

		public void CheckWifiInformation()
		{

			WifiFrequency = wifiInfo.Frequency;
			WifiIpAddress = wifiInfo.IpAddress;
			WifiLinkSpeed = wifiInfo.LinkSpeed;
			WifiMacAddress=  wifiInfo.MacAddress;
			WifiNetworkId =  wifiInfo.NetworkId;
			WifiRssi = wifiInfo.Rssi;

		}


	}
}
