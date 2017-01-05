using System;
using SQLite;

namespace SensorenCBS
{
	public class CBS_Tables
	{
		public CBS_Tables()
		{
			
		}

		public class PickUpPhone
		{
			[PrimaryKey, AutoIncrement]
			public int ID { get; set; }
			public DateTime pickUpDate { get; set; }
		}
	}
}
