using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Android.Content;
using Android.Net.Wifi;
using Plugin.Geolocator;
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
		FetchingGPS _fgps = new FetchingGPS();

		int _size, _level;

		//// inheritance from IWifiConnection
		public string WifiSSID { get; set; }
		public string WifiBSSID { get; set; }
		public int WifiFrequency { get; set; }
		public int WifiLinkSpeed { get; set; }
		public int WifiIpAddress { get; set; }
		public string WifiMacAddress { get; set; }
		public int WifiNetworkId { get; set; }
		public int WifiRssi { get; set; }
		public string WifiRssiLevel { get; set; }
		public List<string> AllWifiBssids { get; set; }
		public List<string> NearbyWifiList { get; set; }
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
			WifiIpAddress = _wifiInfo.IpAddress;
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
		public async void saveNearbyBSSID(DateTime timeSaved)
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

			_size = Results.Count - 1;
			_level = 0;

			while (_size >= 0)
			{
				var _giveLevel = await App.Database.CheckIfBSSIDIsAlreadySavedAndHasLevel(Results[_size].Bssid);
				// id is for saving or update DB with bssid to location

				/// After a random times the application crashes:
				/// System.ArgumentOutOfRangeException: Specified argument was out of the range of valid values. Parameter name: index
				try
				{
					var _idOFTheBSSID = Results[_size].Bssid;
					nearbyBS.BSSID = _idOFTheBSSID;
					nearbyBS.SSID = Results[_size].Ssid;
					nearbyBS.Level = Results[_size].Level;
					nearbyBS.Frequency = Results[_size].Frequency;
					nearbyBS.Cabilities = Results[_size].Capabilities;

					if (_giveLevel.Count > 0) // update
					{
						foreach (var item in _giveLevel) { _level = item.Level; } // get the level of the using bssid

						if (_level > Results[_size].Level) // if level is stronger update else nothing
						{
							nearbyBS.TimeUpdated = _now;
							// update the location
							_fgps.updateGpsFetching(_idOFTheBSSID);
							// update the bssid to the stronger level
							await App.Database.UpdateNearbyBSSID(nearbyBS);
						} // else do nothing
					}
					else // save
					{
						nearbyBS.TimeFirstSaved = _now;
						// save location with bssid
						_fgps.SaveGpsFetching(_idOFTheBSSID);
						// save bssid
						await App.Database.SaveNearbyBSSID(nearbyBS);
					}
					_size--;

				}
				catch (ArgumentOutOfRangeException e)
				{
					Debug.WriteLine("error e: " + e);
				}
			}
		} // while
	}
}

