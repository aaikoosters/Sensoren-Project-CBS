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
		int WifiIpAddress { get;  }
		string WifiMacAddress { get;  }
		int WifiNetworkId { get;  }
		int WifiRssi { get;  }
		List<string> AllWifiBssids { get; }
		List<string> NearbyWifiList { get; }
		//List<KeyValuePair<string, string>> wifiList { get; } // not in use

		string NearbyWifi { get; }
		//List<string> AllNetworkSSID { get; }

		void CheckWifiSSID();
		void CheckWifiBBSID();
		void CheckAllWifiBSSID();
		void CheckWifiInformation();

		void saveNearbyBSSID(DateTime time);
		//void GetNearbyWifi();

		//void CheckWifiPoints();

	}
}
