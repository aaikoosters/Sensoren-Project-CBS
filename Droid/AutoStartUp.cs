using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace SensorenCBS.Droid
{
	public class AutoStartUp : Service
	{
		public override void OnCreate()
		{
			base.OnCreate();
			Toast.MakeText(this, "Service Started", ToastLength.Long).Show();
		}
		public override IBinder OnBind(Intent intent)
		{
			return null;
		}
	}
}
