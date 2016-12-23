using System;
using System.Collections.Generic;
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
		public string WifiIpAddress { get; set; }
		public string WifiMacAddress { get; set; }
		public int WifiNetworkId { get; set; }
		public int WifiRssi { get; set; }
		public string WifiRssiLevel { get; set; }
		public List<string> AllWifiBssids { get; set; }

		List<string> _wifiBssids = new List<string>();


		public void CheckWifiSSID()
		{
			wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
			wifiInfo = wifiManager.ConnectionInfo;
			WifiSSID = wifiInfo.SSID + ", " + wifiInfo.HiddenSSID;
		}

		public void CheckWifiBBSID()
		{
			
			wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
			wifiInfo = wifiManager.ConnectionInfo;

			WifiBSSID = wifiInfo.BSSID;
		}

		public void CheckWifiInformation()
		{
			wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
			wifiInfo = wifiManager.ConnectionInfo;

			WifiFrequency = wifiInfo.Frequency;
			WifiIpAddress = wifiInfo.IpAddress.ToString();
			WifiLinkSpeed = wifiInfo.LinkSpeed;
			WifiMacAddress = wifiInfo.MacAddress;
			WifiNetworkId = wifiInfo.NetworkId;
			WifiRssi = wifiInfo.Rssi;
		}

		public void CheckAllWifiBSSID()
		{
			wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
			wifiInfo = wifiManager.ConnectionInfo;

			if (_wifiBssids.Count == 0 || _wifiBssids[(_wifiBssids.Count - 1)] != wifiInfo.BSSID)
			{
				_wifiBssids.Add(wifiInfo.BSSID);
				AllWifiBssids = _wifiBssids;
			}

		}
	}
}
