using System.Threading.Tasks;
using SQLite;

namespace SensorenCBS
{
	class CBSDatabase
	{
		readonly SQLiteAsyncConnection databaseAsync;

		public CBSDatabase(string dbPath)
		{
			databaseAsync = new SQLiteAsyncConnection(dbPath);
			databaseAsync.CreateTableAsync<CBS_Tables.PickUpPhone>().Wait();
		}

		public Task<int> SaveItemAsyncPickUpPhone(CBS_Tables.PickUpPhone pickUpPhone)
		{
			if (pickUpPhone.ID != 0)
			{
				return databaseAsync.UpdateAsync(pickUpPhone);
			}
			return databaseAsync.InsertAsync(pickUpPhone);
		}

		public Task<int> GetCountedPickUps()
		{
			//return databaseAsync.Table<CBS_Tables.PickUpPhone>().CountAsync(); 
			return databaseAsync.Table<CBS_Tables.PickUpPhone>().CountAsync();
		}
	}
}