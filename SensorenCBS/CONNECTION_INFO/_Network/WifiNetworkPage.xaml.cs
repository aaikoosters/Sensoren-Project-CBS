using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class WifiNetworkPage : ContentPage
	{
		Wifi _wifi;
		DateTime _timeNow;

		public WifiNetworkPage()
		{
			InitializeComponent();
			_wifi = new Wifi();

			checkWifiInformation();
			Device.StartTimer(new TimeSpan(0, 0, 5), () =>
			{
				InitializeComponent();
				checkWifiInformation();
				fetchNearbyWifi();
				CountSavedItems();
				return true;

			});

		}

		void checkWifiInformation()
		{
			saveSSID();
			//ophalen();

			lblTime.Text = DateTime.Now.ToString();
			lblSSID.Text += _wifi.wifiSSID();
			lblBSSID.Text += _wifi.wifiBSSID();
			lblFreq.Text += _wifi.wifiFrequency() + "MHz";
			lblLSP.Text += _wifi.wifiLinkSpeed() + "Mbps";
			lblIpA.Text += _wifi.wifiIpAddress() + "";
			lblMacA.Text += _wifi.wifiMacAddress();
			lblNetI.Text += _wifi.wifiNetworkId() + "";
			lblRssi.Text += _wifi.wifiRssi() + "dBm";
		}

		void saveSSID()
		{
			BindingContext = new Network_ssid();
			var networkSSID = (Network_ssid)BindingContext;
			networkSSID.Ssid = _wifi.wifiSSID();
			networkSSID.Bssid = _wifi.wifiBSSID();
			networkSSID.Frequency = _wifi.wifiFrequency();
			networkSSID.IP = _wifi.wifiIpAddress();
			networkSSID.MAC = _wifi.wifiMacAddress();
			networkSSID.NetworkID = _wifi.wifiNetworkId();
			networkSSID.Rssi = _wifi.wifiRssi();
			App.Database.SaveSsidAsyncNetwork(networkSSID);
		}

		void fetchNearbyWifi()
		{
			_timeNow = DateTime.Now;
			/// call wifi class who calls the Interface
			/// The working function can you find in WifiConnection.droid of .ios
			_wifi.FetchNearbyBSSID(_timeNow);


		}

		async void CountSavedItems()
		{
			var giveNearby = await App.Database.WifiWithLocatie(); //GetNearbyBSSID();
			var _CountedAccesPoints = await App.Database.CountSavedBSSID();
			var _CountedAccesWithGPS = await App.Database.CountedAccesWithGPS();

			lblCountedAccesPoints.Text = string.Format("Saved Acces points: {0}", _CountedAccesPoints);
			lblCountedAccesWithGPS.Text = string.Format("Saved Acces Point with GPS: {0}", _CountedAccesWithGPS);

			//foreach (var item in giveNearby)
			//{
			//	Debug.WriteLine(string.Format("{0}, {1:0.0000000}, {2:0.0000000}, {3}", item.idBSSID, item.Latitude, item.Longitude, item.IDlocation));
			//	//lblAllBSSID.Text += "\n" + item.BSSID + ", " + item.Level;
			//}
			//Debug.WriteLine("------------------------------");
		}
	}
}
