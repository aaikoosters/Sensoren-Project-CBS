using Xamarin.Forms;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace SensorenCBS
{
	public partial class App : Application
	{
		static CBSDatabase database;

		public App()
		{
			InitializeComponent();
			MobileCenter.Start(typeof(Analytics), typeof(Crashes));
			MainPage = new NavigationPage(new SensorenCBSPage());
		}

		public static CBSDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new CBSDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("CBSSQLite.db3"));
				}
				return database;
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
