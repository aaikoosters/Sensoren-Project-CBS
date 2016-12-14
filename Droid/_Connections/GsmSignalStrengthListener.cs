using System;
using Android.Telephony;

namespace SensorenCBS.Droid
{
	public class GsmSignalStrengthListener: PhoneStateListener
	{
		public delegate void SignalStrengthChangedDelegate(int strength);

		public event SignalStrengthChangedDelegate SignalStrengthChanged;

		public override void OnSignalStrengthsChanged(SignalStrength signalStrength)
		{
			if (signalStrength.IsGsm)
			{
				if (SignalStrengthChanged != null)
				{
					SignalStrengthChanged(signalStrength.GsmSignalStrength);
				}
			}
		}
	}
}
