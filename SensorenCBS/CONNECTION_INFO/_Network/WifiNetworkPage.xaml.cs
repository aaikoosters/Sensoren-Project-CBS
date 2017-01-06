using System;
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
			checkWifiInformation();
			Device.StartTimer(new TimeSpan(0, 0, 5), () =>
			{
				InitializeComponent();
				BindingContext = new Network_ssid();
				checkWifiInformation();
				return true;

			});

		}

		void checkWifiInformation()
		{
			BindingContext = new Network_ssid();

			savings();
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
				lblAllBSSID.Text += "\n" + bs; 
			}

		}

		void savings()
		{
			var networkSSID = (Network_ssid)BindingContext;
			networkSSID.Ssid = wifi.wifiSSID();
			networkSSID.Bssid = wifi.wifiBSSID();
			App.PickUpDatabase.SaveItemAsyncNetwork(networkSSID);
		}

		async void ophalen()
		{
			var turing = await App.PickUpDatabase.GetCountedSSID();
			lblTime.Text = "aantal veschillende ssid's: " + turing.ToString();
			//lblPickedUp.Text = "Times picked up: " + turing.ToString();
		}
	}
}
