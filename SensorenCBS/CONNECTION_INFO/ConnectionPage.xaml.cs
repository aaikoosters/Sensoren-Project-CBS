using System;

using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class ConnectionPage : ContentPage
	{
		public ConnectionPage()
		{
			InitializeComponent();
			if (Device.OS == TargetPlatform.iOS)
			{
				btnNearby.IsVisible = false;
			}
		}

		void btnWifi(object s, EventArgs e)
		{
			Navigation.PushAsync(new NetworkPage());
		}

		void btnBlue(object s, EventArgs e)
		{
			Navigation.PushAsync(new BluetoothPage());
		}

		void btnNearbyClicked(object s, EventArgs e)
		{
			Navigation.PushAsync(new NearbyPage());
		}
	}
}
