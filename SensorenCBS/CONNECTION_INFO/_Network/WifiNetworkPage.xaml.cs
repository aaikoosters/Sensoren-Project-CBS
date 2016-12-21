using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class WifiNetworkPage : ContentPage
	{
		Wifi wifi;
		string wifiBSSIDCon;
		List<string> bssids = new List<string>();

		public WifiNetworkPage()
		{
			InitializeComponent();
			wifi = new Wifi();
			checkWifiInformation();
			Device.StartTimer(new TimeSpan(0, 0, 59), () =>
			{
				InitializeComponent();
				checkWifiInformation();
				return true;

			});

		}

		void checkWifiInformation()
		{
			wifiBSSIDCon = wifi.wifiBSSID();
			//wifi.
			bssids.Add(wifiBSSIDCon);
			

			lblTime.Text = DateTime.Now.ToString();
			lblSSID.Text += wifi.wifiSSID();
			lblBSSID.Text += wifiBSSIDCon;
			lblFreq.Text += wifi.wifiFrequency() + "MHz";
			lblLSP.Text += wifi.wifiLinkSpeed() + "Mbps";
			lblIpA.Text += wifi.wifiIpAddress() + "";
			lblMacA.Text += wifi.wifiMacAddress();
			lblNetI.Text += wifi.wifiNetworkId() + "";
			lblRssi.Text += wifi.wifiRssi() + "dBm";

			foreach (var bs in bssids)
			{
				lblAllBSSID.Text += "\n" + bs; 
			}

		}
	}
}
