using System;
using Android.App;
using Android.Content;
using Android.Widget;

namespace SensorenCBS.Droid
{
	//[BroadcastReceiver]
	//[IntentFilter(new[] { Intent.ActionBootCompleted })]
	public class BootCompletedBroadcastReceiver : BroadcastReceiver
	{
		public BootCompletedBroadcastReceiver()
		{
		}

		public override void OnReceive(Context context, Intent intent)
		{
			if (intent.Action == Intent.ActionBootCompleted)
			{
				Toast.MakeText(context, "Broadcast catched, start own application", ToastLength.Long).Show();
				Intent applicationIntent = new Intent(context, typeof(MainActivity));
				applicationIntent.AddFlags(ActivityFlags.NewTask);
				context.StartActivity(applicationIntent);
			}
		}
	}
}
