using System;
using SQLite;
namespace SensorenCBS
{
	public class NearbyBSSID
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public DateTime time { get; set; }
		public string BSSID { get; set; }
		public string SSID { get; set; }
		public int Level { get; set; }
		public int Frequency { get; set; }
		public string Cabilities { get; set; }
	}

	public class AllNearbyBSSID
	{

	}
}
