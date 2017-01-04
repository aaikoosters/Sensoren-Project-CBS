using System;
namespace SensorenCBS
{
	public class SQLite_Tables
	{
		public class PickedUpTable
		{
			[PrimaryKey, AutoIncrement]
			public int ID { get; set; }
			public DateTime timeAndDay { get; set; }
			public bool pickedUp { get; set; }
		}
	}
}
