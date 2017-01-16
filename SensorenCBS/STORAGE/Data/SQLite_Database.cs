using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace SensorenCBS
{
	public class SQLite_Database
	{
		readonly SQLiteAsyncConnection database;

		public SQLite_Database(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<PickedUp>().Wait();
			database.CreateTableAsync<Network_ssid>().Wait();
			database.CreateTableAsync<NearbyBSSID>().Wait();
		}

		//pickup
		public Task<List<PickedUp>> GetItemsAsync()
		{
			return database.Table<PickedUp>().ToListAsync();
		}

		//pickup
		public Task<PickedUp> GetItemAsync(int id)
		{
			return database.Table<PickedUp>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		//pickup
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

		//pickup
		public Task<int> DeleteItemAsync(PickedUp item)
		{
			return database.DeleteAsync(item);
		}

		//pickup
		public Task<int> GetCountedPickUps()
		{
			//return databaseAsync.Table<CBS_Tables.PickUpPhone>().CountAsync(); 
			var turning = database.Table<PickedUp>().CountAsync();
			return turning;
		}


		public bool getPossibleSSID(string ssid)
		{
			var isSsidFilled = database.Table<Network_ssid>().Where(s => s.Ssid == ssid).FirstAsync().ToString();
			if (isSsidFilled.Equals("")) { return true; }
			return false;
		}

		//network
		public Task<int> SaveSsidAsyncNetwork(Network_ssid item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			return database.InsertAsync(item);
		}


		//network
		public Task<int> GetCountedSSID()
		{
			//return databaseAsync.Table<CBS_Tables.PickUpPhone>().CountAsync(); 
			var turning = database.Table<Network_ssid>().CountAsync();
			return turning;
		}

		// NEARBY
		public Task<int> SaveNearbyBSSID(NearbyBSSID item)
		{
			var know = database.Table<NearbyBSSID>().Where(i => i.BSSID == item.BSSID).FirstOrDefaultAsync();

			if (item.BSSID.Equals(know))
			{
				return database.UpdateAsync(item);
			}
			return database.InsertAsync(item);
		}

		//pickup
		public Task<List<NearbyBSSID>> GetNearbyBSSID()
		{
			return database.Table<NearbyBSSID>().ToListAsync();
		}

	}
}	