﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class WifiNetworkPage : ContentPage
	{
		Wifi wifi;
		List<string> bssids = new List<string>();

		public WifiNetworkPage()
		{
			InitializeComponent();
			wifi = new Wifi();
			BindingContext = new Network_ssid();

			checkWifiInformation();
			Device.StartTimer(new TimeSpan(0, 0, 5), () =>
			{
				InitializeComponent();
				checkWifiInformation();
				scanNearbyWifi();
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
			
			App.PickUpDatabase.SaveSsidAsyncNetwork(networkSSID);
		}

		void scanNearbyWifi()
		{
			var nearbyWifi = wifi.wifiList();
			foreach (string pair in nearbyWifi)
			{
				lblAllBSSID.Text += ("\n" + pair);
			}
			//lblAllBSSID.Text = nearbyWifi;
		}

		async void ophalen()
		{
			var turing = await App.PickUpDatabase.GetCountedSSID();
			lblTime.Text = "aantal veschillende ssid's: " + turing.ToString();
			//lblPickedUp.Text = "Times picked up: " + turing.ToString();
		}
	}
}
