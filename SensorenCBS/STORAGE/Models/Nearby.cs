using System;
using SQLite;
namespace SensorenCBS
{
	public class NearbyBSSID
	{
		
		[PrimaryKey]
		public string BSSID { get; set; }
		public string SSID { get; set; }
		public int Level { get; set; }
		public int Frequency { get; set; }
		public string Cabilities { get; set; }
		//public DateTime Time { get; set; }
		public DateTime TimeNow { get; set; }
		
	}

	public class AllNearbyBSSID
	{

	}
}
