using System;
using SQLite;
namespace SensorenCBS
{
	public class NearbyBSSID
	{
		//[PrimaryKey, AutoIncrement]
		//public int bssidID { get; set; }
		//[PrimaryKey, AutoIncrement]
		//public int IDbssid { get; set; }
		[PrimaryKey]
		public string BSSID { get; set; }
		public string SSID { get; set; }
		public int Level { get; set; }
		public int Frequency { get; set; }
		public string Cabilities { get; set; }
		public DateTime TimeFirstSaved { get; set; }
		public DateTime TimeUpdated { get; set; }
		
	}

	public class LocationDB
	{
		[AutoIncrement, PrimaryKey]
		public int IDlocation { get; set; }
		public DateTime Time { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public double Accuracy { get; set; }
		// foreign key
		public string idBSSID { get; set; }
	}

	public class NearbyWithLocation
	{
		[PrimaryKey, AutoIncrement]
		public int NearbyLocationID { get; set; }
		public int locationID { get; set; }
		public string NearbyBSSID { get; set;}

	}
}
