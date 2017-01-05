using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace SensorenCBS
{
	public class CBSDataDatabase
	{
		readonly SQLiteAsyncConnection database;

		public CBSDataDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<CBSItem>().Wait();
		}

		public Task<List<CBSItem>> CountPickedUp()
		{
			return (database.QueryAsync<CBSItem>("SELECT COUNT(*) FROM [CBSItem]"));

		}


		public IEnumerable<CBSItem> QueryPickUps()
		{
			return (IEnumerable<CBSItem>)database.QueryAsync<CBSItem>("Select count(*) from CBSItem");

		}

		public string GetCountedPickUps()
		{
			//return databaseAsync.Table<CBS_Tables.PickUpPhone>().CountAsync(); 
			var teruns =  database.Table<CBSItem>().CountAsync().ToString();
			return teruns;
		}


		public Task<int> SaveItemAsync(CBSItem item)
		{
			//if (item.timeAndDay != DateTime.Now)
			//{
			//	return database.UpdateAsync(item);
			//}
			return database.InsertAsync(item);
		}

		public Task<List<CBSItem>> GetItemsAsync()
		{
			return database.Table<CBSItem>().ToListAsync();
		}
	}
}
