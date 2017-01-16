using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class NearbyPage : ContentPage
	{
		public NearbyPage()
		{
			InitializeComponent();
			ophalen();
		}

		async void ophalen()
		{
			var giveNearbyNetwork = await App.Database.GetBSSIDSNearbyAsync(DateTime.Now);
			foreach (var item in giveNearbyNetwork)
			{
				lblAllBSSID.Text += "\n" + item.BSSID + ", " + item.time + ", " + item.ID;
			}
			//lblPickedUp.Text = "Times picked up: " + turing.ToString();
		}
	}
}
