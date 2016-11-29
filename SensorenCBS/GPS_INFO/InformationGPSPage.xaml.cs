using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace SensorenCBS
{
	public partial class InformationGPSPage : ContentPage
	{
		// Hier mee roep je de plugin aan om te kunnen gebruiken
		Plugin.Geolocator.Abstractions.IGeolocator locator = CrossGeolocator.Current;

		public const int Timeout = 30 * 1000; // 30s
		public const double DefaultAccurancy = 1000; // 1000m

		public InformationGPSPage()
		{
			InitializeComponent();
			
		}

		async void btnGPSInfo(object s, EventArgs e)
		{
			try
			{
				lblInfo.Text = "Fetching your location";
				locator.DesiredAccuracy = DefaultAccurancy; // de gewenste nauwkeurigheid in meters

				var position = await locator.GetPositionAsync(timeoutMilliseconds: Timeout); // Geeft de tijd aan hoelang er maximaal gewacht gaat worden om de locatie te kunnen ophalen
				if (position == null) // dus geen locatie door gekregen
				{
					lblInfo.Text = "There is no GPS Information";
					return;
				}
				lblInfo.Text = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
					position.Timestamp, position.Latitude, position.Longitude,
					position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);
			} catch (TaskCanceledException)
			{
				lblInfo.Text = "There is no GPS Information";
				await DisplayAlert("Error Location", "Fetching the location takes to much time", "OK");
			}
		}
	}
}
