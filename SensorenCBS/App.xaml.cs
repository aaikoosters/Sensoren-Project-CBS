using Xamarin.Forms;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace SensorenCBS
{
	public partial class App : Application
	{
		static CBSDataDatabase database;

		public App()
		{
			InitializeComponent();
			MobileCenter.Start(typeof(Analytics), typeof(Crashes));
			MainPage = new NavigationPage(new SensorenCBSPage());
		}

		public static CBSDataDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new CBSDataDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("CBSSQLite.db3"));
				}
				return database;
			}
		}

		public int ResumeAtCBSId { get; set; }


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
