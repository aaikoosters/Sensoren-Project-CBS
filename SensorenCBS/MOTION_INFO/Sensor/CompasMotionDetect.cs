using System;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;

namespace SensorenCBS
{
	public class CompasMotionDetect
	{
		Label _label;
		public CompasMotionDetect(Label label, SensorValueChangedEventArgs svca)
		{
			_label = label;
			CompasDetect(svca);
		}

		void CompasDetect(SensorValueChangedEventArgs b)
		{
			var or = (b.Value.Value);
			_label.Text = heading(or);
		}

		string heading(double? or)
		{
			string[] caridnals = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };
			return "Compas\n" + caridnals[(int)Math.Round(((double)or * 10 % 3600) / 225)] + ", " + string.Format("{0:0}", or);
		}
	}
}
