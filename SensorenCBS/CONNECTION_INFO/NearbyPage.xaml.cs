using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class NearbyPage : ContentPage
	{
		DateTime timeNow;
		Wifi wifi = new Wifi();

		public NearbyPage()
		{
			InitializeComponent();
			fetchNearbyWifi();
			printNearbyBSSID();
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
//=======
			//var giveNearby = await App.Database.WifiWithLocatie(); //GetNearbyBSSID();
			lblAllBSSID.Text = "";
			//foreach (var item in giveNearby)
//>>>>>>> origin/master
			{
				// fout bij te veel waardes!!!
				lblAllBSSID.Text += (string.Format("{0}, {1}, {2}", item.BSSID, item.Level, item.Frequency));

				//lblAllBSSID.Text += "\n" + item.BSSID + ", " + item.Level;
			}
		}

	}
}
