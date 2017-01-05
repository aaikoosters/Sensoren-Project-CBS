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
}