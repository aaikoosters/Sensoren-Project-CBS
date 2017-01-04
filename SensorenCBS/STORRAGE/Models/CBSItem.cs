using System;
using SQLite;
namespace SensorenCBS
{
	public class CBSItem
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public DateTime timeAndDay { get; set; }
		public bool pickedUp { get; set; }
	}
}
