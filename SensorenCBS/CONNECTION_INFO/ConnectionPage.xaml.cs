﻿using System;
using System.Collections.Generic;

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
	}
}
