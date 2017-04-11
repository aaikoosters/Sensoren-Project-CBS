using System;
using System.Collections.Generic;

namespace SensorenCBS
{
	public interface IWifiConnection
	{

		string WifiSSID { get;  }
		string WifiBSSID { get;  }
		int WifiFrequency { get;  }
		int WifiLinkSpeed { get;  }
		string WifiIpAddress { get;  }
		string WifiMacAddress { get;  }
		int WifiNetworkId { get;  }
		int WifiRssi { get;  }
		List<string> AllWifiBssids { get; }
		List<string> NearbyWifiList { get; }

		string NearbyWifi { get; }

		void CheckWifiSSID();
		void CheckWifiBBSID();
		void CheckAllWifiBSSID();
		void CheckWifiInformation();

		void FetchNearbyWifi(DateTime time);

	}
}
