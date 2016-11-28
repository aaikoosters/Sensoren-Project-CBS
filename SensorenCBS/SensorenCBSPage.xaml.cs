using System;
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
	}
}
