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
			Navigation.PushAsync(new InformationGPSPage());
		}

		void btnMTN(object s, EventArgs e)
		{
			Navigation.PushAsync(new MotionPage());
		}

		void btnConn(object s, EventArgs e)
		{
			Navigation.PushAsync(new ConnectionPage());
		}
	}
}
