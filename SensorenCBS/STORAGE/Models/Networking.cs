using System;
using System.Collections.Generic;
using SQLite;

namespace SensorenCBS
{
	public class Network_ssid
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Ssid { get; set; }
		public string Bssid { get; set; }
		public int Frequency { get; set; }
		public int IP { get; set; }
		public string MAC { get; set; }
		public int NetworkID { get; set; }
		public int Rssi { get; set; }

	}
}
