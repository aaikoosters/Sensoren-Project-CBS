using System;
using System.Threading.Tasks;
using SQLite;

namespace SensorenCBS
{
	public class Network_Database
	{
		readonly SQLiteAsyncConnection database;
		

		public Network_Database(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<PickedUp>().Wait();
		}

		public Task<int> SaveSSID(Network_ssid item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else {
				return database.InsertAsync(item);
			}
		}

		public Task<int> CountSSID()
		{
			var turning = database.Table<PickedUp>().CountAsync();
			return turning;
		}
	}
}
