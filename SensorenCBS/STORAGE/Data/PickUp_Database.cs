using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace SensorenCBS
{
	public class PickUp_Database
	{
		readonly SQLiteAsyncConnection database;

		public PickUp_Database(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<PickedUp>().Wait();
		}

		public Task<List<PickedUp>> GetItemsAsync()
		{
			return database.Table<PickedUp>().ToListAsync();
		}

		public Task<PickedUp> GetItemAsync(int id)
		{
			return database.Table<PickedUp>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(PickedUp item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else {
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(PickedUp item)
		{
			return database.DeleteAsync(item);
		}

		public Task<int> GetCountedPickUps()
		{
			//return databaseAsync.Table<CBS_Tables.PickUpPhone>().CountAsync(); 
			var turning =  database.Table<PickedUp>().CountAsync();
			return turning;
		}
	}
}	