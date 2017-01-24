using System;
using System.Collections.Generic;
using System.Linq;
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

		//// The WiFiManager and the WiFiInfo are the Assembly Implementation to use/read information from WiFi
		//// U need to use Android.Net.Wifi to implement it.
		WifiManager wifiManager;
		WifiInfo wifiInfo;

		//// inheritance from IWifiConnection
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
		public List<string> NearbyWifiList { get; set; }
		////public List<KeyValuePair<string, string>> wifiList { get; set; }


		public IList<ScanResult> Results { get; set; }
		public string NearbyWifi { get; set; }

		//// private list to add bssids to the public stack: AllWifiBssids
		List<string> _wifiBssids = new List<string>();


		//// With this u can check the SSID from the connected WiFi
		public void CheckWifiSSID()
		{
			wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
			wifiInfo = wifiManager.ConnectionInfo;
			WifiSSID = wifiInfo.SSID + ", " + wifiInfo.HiddenSSID;
		}

		//// the BSSID, in the form of a six-byte MAC address: XX:XX:XX:XX:XX:XX
		public void CheckWifiBBSID()
		{
			wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
			wifiInfo = wifiManager.ConnectionInfo;
			//// BSSID is the name of the acces point u are using
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
			//// the network ID, or -1 if there is no currently connected network
			WifiNetworkId = wifiInfo.NetworkId;
			//// Returns the received signal strength indicator of the current 802.11 network, in dBm.
			WifiRssi = wifiInfo.Rssi;
		}

		public void CheckAllWifiBSSID()
		{
			wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
			wifiInfo = wifiManager.ConnectionInfo;
			//// In this method there is a check or the bssid is a new/unique bssid
			if (_wifiBssids.Count == 0 || _wifiBssids[(_wifiBssids.Count - 1)] != wifiInfo.BSSID)
			{
				_wifiBssids.Add(wifiInfo.BSSID);
				AllWifiBssids = _wifiBssids;
			}

		}

		//Dictionary<string, string> dictionary;
		//// Fetching the native nearby Wifi Connection and save it to the database
		public async void FetchNearbyWifi(DateTime timeSaved)
		{
			//// make the connection to the database
			object BindingContext = new NearbyBSSID();
			var nearbyBS = (NearbyBSSID)BindingContext;

			wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
			if (wifiManager.IsWifiEnabled == false)
			{
				wifiManager.SetWifiEnabled(true);
			}
			Results = wifiManager.ScanResults;

			var size = Results.Count;
			size = size - 1;
			int aantal = 0;
			var level = 0;
			while (size >= 0)
			{
				var _giveLevel = await App.Database.CheckIfBSSIDIsAlreadySavedAndHasLevel(Results[size].Bssid); //GetNearbyBSSID();

				nearbyBS.BSSID = Results[size].Bssid;
				nearbyBS.SSID = Results[size].Ssid;
				nearbyBS.Level = Results[size].Level;
				nearbyBS.Frequency = Results[size].Frequency;
				nearbyBS.Cabilities = Results[size].Capabilities;


				if (_giveLevel.Count > 0) // update
				{
					foreach (var item in _giveLevel)
					{
						level = item.Level;
					}
					if (level < Results[size].Level)
					{
						nearbyBS.TimeUpdated = timeSaved;
						await App.Database.UpdateNearbyBSSID(nearbyBS);
					}
				}
				else // save
				{
					nearbyBS.TimeFirstSaved = timeSaved;
					await App.Database.SaveNearbyBSSID(nearbyBS);
				}

				Console.WriteLine(nearbyBS + ", " + nearbyBS.BSSID + ", " + nearbyBS.TimeFirstSaved + ", " + nearbyBS.TimeUpdated);

				size--;
				aantal++;
			}
			Console.WriteLine("-------------" + aantal + "----------------------");
		}
	}
}

