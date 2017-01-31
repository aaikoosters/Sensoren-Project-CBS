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
		WifiManager _wifiManager;
		WifiInfo _wifiInfo;
		DateTime _now;
		FetchingGPS _fetchGPS;

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
		///public List<KeyValuePair<string, string>> wifiList { get; set; }


		public IList<ScanResult> Results { get; set; }
		public string NearbyWifi { get; set; }

		/// private list to add bssids to the public stack: AllWifiBssids
		List<string> _wifiBssids = new List<string>();


		/// With this u can check the SSID from the connected WiFi
		public void CheckWifiSSID()
		{
			_wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
			_wifiInfo = _wifiManager.ConnectionInfo;
			WifiSSID = _wifiInfo.SSID + ", " + _wifiInfo.HiddenSSID;
		}

		/// the BSSID, in the form of a six-byte MAC address: XX:XX:XX:XX:XX:XX
		public void CheckWifiBBSID()
		{
			_wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
			_wifiInfo = _wifiManager.ConnectionInfo;
			/// BSSID is the name of the acces point u are using
			WifiBSSID = _wifiInfo.BSSID;
		}

		public void CheckWifiInformation()
		{
			_wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
			_wifiInfo = _wifiManager.ConnectionInfo;

			WifiFrequency = _wifiInfo.Frequency;
			WifiIpAddress = _wifiInfo.IpAddress.ToString();
			WifiLinkSpeed = _wifiInfo.LinkSpeed;
			WifiMacAddress = _wifiInfo.MacAddress;
			//// the network ID, or -1 if there is no currently connected network
			WifiNetworkId = _wifiInfo.NetworkId;
			//// Returns the received signal strength indicator of the current 802.11 network, in dBm.
			WifiRssi = _wifiInfo.Rssi;
		}

		public void CheckAllWifiBSSID()
		{
			_wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
			_wifiInfo = _wifiManager.ConnectionInfo;
			//// In this method there is a check or the bssid is a new/unique bssid
			if (_wifiBssids.Count == 0 || _wifiBssids[(_wifiBssids.Count - 1)] != _wifiInfo.BSSID)
			{
				_wifiBssids.Add(_wifiInfo.BSSID);
				AllWifiBssids = _wifiBssids;
			}

		}

		//// Fetching the native nearby Wifi Connection and save it to the database
		public async void FetchNearbyWifi(DateTime timeSaved)
		{
			_now = timeSaved;

			//// make the connection to the database
			object BindingContext = new NearbyBSSID();
			var nearbyBS = (NearbyBSSID)BindingContext;

			_wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
			if (_wifiManager.IsWifiEnabled == false)
			{
				_wifiManager.SetWifiEnabled(true);
			}
			Results = _wifiManager.ScanResults;

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
					foreach (var item in _giveLevel) { level = item.Level; }

					if (level < Results[size].Level)
					{
						nearbyBS.TimeUpdated = _now;
						//_fetchGPS.updateFetchedGPS(nearbyBS.IDbssid);
						await App.Database.UpdateNearbyBSSID(nearbyBS);
					} // else do nothing
				}
				else // save
				{
					nearbyBS.TimeFirstSaved = _now;
					//_fetchGPS.saveFetchedGPS(nearbyBS.IDbssid);
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

