using System;
using System.Collections.Generic;

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
				checkWifiInformation();
				return true;

			});

		}

		void checkWifiInformation()
		{
			lblTime.Text = DateTime.Now.ToString();
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
	}
}
