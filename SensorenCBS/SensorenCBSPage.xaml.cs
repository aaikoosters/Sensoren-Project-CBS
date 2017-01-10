using System;
using System.Diagnostics;
using Microsoft.Azure.Mobile;
using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class SensorenCBSPage : ContentPage
	{
		public SensorenCBSPage()
		{
			InitializeComponent();
		}

		void btnGPS(object s, EventArgs e)
		{
			// Opens the page with information about current GPS usages
			Navigation.PushAsync(new InformationGPSPage());
		}

		void btnMTN(object s, EventArgs e)
		{
			// Opens the page with Motion Information
			Navigation.PushAsync(new MotionPage());
		}

		void btnConn(object s, EventArgs e)
		{
			// Opens the pages with the 2 types of connection:
			// - Network
			// - Bluetooth
			Navigation.PushAsync(new ConnectionPage());
		}
	}
}
