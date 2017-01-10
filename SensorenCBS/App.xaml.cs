using Xamarin.Forms;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace SensorenCBS
{
	public partial class App : Application
	{
		static PickUp_Database pickup_database;
		//static Network_Database network_database;

		public App()
		{
			InitializeComponent();
			MobileCenter.Start(typeof(Analytics), typeof(Crashes));
			MainPage = new NavigationPage(new SensorenCBSPage());
		}

		public static PickUp_Database PickUpDatabase
		{
			get
			{
				if (pickup_database == null)
				{
					pickup_database = new PickUp_Database(DependencyService.Get<IFileHelper>().GetLocalFilePath("CBSSQLite.db3"));
				}
				return pickup_database;
			}
		}

		//public static Network_Database NetworkDatabase
		//{
		//	get
		//	{
		//		if (network_database == null)
		//		{
		//			network_database = new Network_Database(DependencyService.Get<IFileHelper>().GetLocalFilePath("Network.db3"));
		//		}
		//		return network_database;
		//	}
		//}

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
