using System;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;

namespace SensorenCBS
{
	public class CompasMotionDetect
	{
		Label _label;
		public string orCompas { get; set; }
		
		public CompasMotionDetect(SensorValueChangedEventArgs svca)
		{
			// start processing compass
			CompasDetect(svca);
		}

		void CompasDetect(SensorValueChangedEventArgs b)
		{
			// set variable
			var _compasDegrees = (b.Value.Value);
			// set label text with the heading and the grades
			orCompas = heading(_compasDegrees);
		}

		string heading(double? _compasDegrees)
		{
			string[] _caridnals = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };
			return "Compas\n" + _caridnals[(int)Math.Round(((double)_compasDegrees * 10 % 3600) / 225)] + ", " + string.Format("{0:0}", _compasDegrees);
		}
	}
}
