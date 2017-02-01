using System;

using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class ConnectionPage : ContentPage
	{
		public ConnectionPage()
		{
			InitializeComponent();
		}

		void btnWifi(object s, EventArgs e)
		{
			Navigation.PushAsync(new NetworkPage());
		}

		void btnBlue(object s, EventArgs e)
		{
			Navigation.PushAsync(new BluetoothPage());
		}

		void btnNearby(object s, EventArgs e)
		{
			Navigation.PushAsync(new NearbyPage());
		}
	}
}
