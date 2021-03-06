﻿using Xamarin.Forms;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace SensorenCBS
{
	public partial class App : Application
	{
		static SQLite_Database pickup_database;

		public App()
		{
			InitializeComponent();
			MobileCenter.Start(typeof(Analytics), typeof(Crashes));
			MainPage = new NavigationPage(new SensorenCBSPage());
		}

		public static SQLite_Database Database
		{
			get
			{
				if (pickup_database == null)
				{
					pickup_database = new SQLite_Database(DependencyService.Get<IFileHelperDatabase>().GetLocalFilePath("CBSSQLite.db3"));
				}
				return pickup_database;
			}
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
