using System;
using System.Diagnostics;
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
			Navigation.PushAsync(new InformationGPSPage());
		}

		void btnMTN(object s, EventArgs e)
		{
			Navigation.PushAsync(new MotionPage());
		}

		void btnWifi(object s, EventArgs e)
		{
			Navigation.PushAsync(new NetworkPage());
		}


	}
}
