using System;
using SQLite;

namespace SensorenCBS
{
	public class PickedUp
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public DateTime TimeDay { get; set; }
	}

	public class Network_ssid
	{
		[PrimaryKey]
		public int ID { get; set; }
		public string Ssid { get; set; }
		public string Bssid { get; set; }
		public int Frequency { get; set; }
		public string IP { get; set; }
		public string MAC { get; set; }
		public int NetworkID { get; set; }
		public int Rssi { get; set; }

	}

	public class Network_bssid
	{
		[PrimaryKey]
		public int Bssid { get; set;}
		public string Ssid { get; set; }
		public DateTime time { get; set; }
	}
}