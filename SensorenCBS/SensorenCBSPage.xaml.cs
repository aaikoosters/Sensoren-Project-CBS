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
			checkDevice();
		}

		void btnGPS(object s, EventArgs e)
		{
			Navigation.PushAsync(new InformationGPSPage());
		}

		void btnMTN(object s, EventArgs e)
		{
			Navigation.PushAsync(new MotionPage());
		}

		void checkDevice()
		{
			if (Device.OS != TargetPlatform.Android) 
			{
				btnAndroidLocation.IsVisible = false;
			}
		}
		void btnAndroidLocationCL(object s, EventArgs e)
		{
			Debug.WriteLine("btnAndroidLocation");
		}


	}
}
