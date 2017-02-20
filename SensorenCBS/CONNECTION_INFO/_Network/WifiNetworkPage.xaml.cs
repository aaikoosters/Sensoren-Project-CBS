using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class WifiNetworkPage : ContentPage
	{
		Wifi wifi;
		DateTime timeNow;

		public WifiNetworkPage()
		{
			InitializeComponent();
			wifi = new Wifi();
			//BindingContext = new Network_ssid();

			checkWifiInformation();
			Device.StartTimer(new TimeSpan(0, 0, 5), () =>
			{
				InitializeComponent();
				checkWifiInformation();
				fetchNearbyWifi();
				printNearbyBSSID();
				return true;

			});

		}

		void checkWifiInformation()
		{
			BindingContext = new Network_ssid();
			saveSSID();
			ophalen();

			//lblTime.Text = DateTime.Now.ToString();
			lblSSID.Text += wifi.wifiSSID();
			lblBSSID.Text += wifi.wifiBSSID();
			lblFreq.Text += wifi.wifiFrequency() + "MHz";
			lblLSP.Text += wifi.wifiLinkSpeed() + "Mbps";
			lblIpA.Text += wifi.wifiIpAddress() + "";
			lblMacA.Text += wifi.wifiMacAddress();
			lblNetI.Text += wifi.wifiNetworkId() + "";
			lblRssi.Text += wifi.wifiRssi() + "dBm";

			//lblAllBSSID.Text = "\n"+ wifi.wifiAllBSSID();

			foreach (var bs in wifi.wifiAllBSSID())
			{
				//lblAllBSSID.Text += "\n" + bs; 
			}

		}

		void saveSSID()
		{
			var networkSSID = (Network_ssid)BindingContext;
			networkSSID.Ssid = wifi.wifiSSID();
			networkSSID.Bssid = wifi.wifiBSSID();
			networkSSID.Frequency = wifi.wifiFrequency();
			networkSSID.IP = wifi.wifiIpAddress();
			networkSSID.MAC = wifi.wifiMacAddress();
			networkSSID.NetworkID = wifi.wifiNetworkId();
			networkSSID.Rssi = wifi.wifiRssi();
			App.Database.SaveSsidAsyncNetwork(networkSSID);
		}

		void fetchNearbyWifi()
		{
			timeNow = DateTime.Now;
			/// call wifi class who calls the Interface
			/// The working function can you find in WifiConnection.droid of .ios
			wifi.FetchNearbyWifi(timeNow);


		}

		async void printNearbyBSSID()
		{
			var giveNearby = await App.Database.WifiWithLocatie(); //GetNearbyBSSID();
			lblAllBSSID.Text = "";
			foreach (var item in giveNearby)
			{
				// fout bij te veel waardes!!!
				//lblAllBSSID.Text += (string.Format("{0}, {1}, {2}, {3}\n", item.BSSID, item.Frequency, item.Level, item.SSID));
				//lblAllBSSID.Text += (string.Format("{0}, {1}, {2}\n", item.idBSSID, item.Latitude, item.Longitude));
				

				Debug.WriteLine(string.Format("{0}, {1:0.0000000}, {2:0.0000000}, {3}", item.idBSSID, item.Latitude, item.Longitude, item.IDlocation));
				//lblAllBSSID.Text += "\n" + item.BSSID + ", " + item.Level;
			}
			Debug.WriteLine("------------------------------");
		}

		async void ophalen()
		{
			//var turing = await App.Database.GetCountedSSID();
			var countNearby = await App.Database.CountWifiWithLocatie();
			
			lblTime.Text = "All BSSIDS's: " + countNearby;

			//var giveNearbyNetwork = await App.Database.GetNearbyBSSID(timeNow);
			//var giveNearby = await App.Database.GetItemsNotDoneAsync(); //GetNearbyBSSID();
			//lblAllBSSID.Text = "";
			//foreach (var item in giveNearby)
			//{
			//	// fout bij te veel waardes!!!
			//	lblAllBSSID.Text += ("\n" + item.BSSID + ", " + item.Level + ", " + item.TimeFirstSaved + ", " + item.TimeUpdated);
				
			//	//lblAllBSSID.Text += "\n" + item.BSSID + ", " + item.Level;
			//}
			//lblPickedUp.Text = "Times picked up: " + turing.ToString();
		}
	}
}
