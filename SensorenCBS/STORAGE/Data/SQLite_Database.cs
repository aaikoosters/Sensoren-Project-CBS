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
			database.CreateTableAsync<LocationDB>().Wait();
			database.CreateTableAsync<NearbyWithLocation>().Wait();
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
			var turning = database.Table<Network_ssid>().Take(1).CountAsync();
			return turning;
		}

		// NEARBY
		public Task<int> SaveNearbyBSSID(NearbyBSSID item)
		{
			return database.InsertAsync(item);
		}

		public Task<List<NearbyBSSID>> UpdateNearbyBSSID(NearbyBSSID item)
		{

			return database.QueryAsync<NearbyBSSID>(string.Format(
				" UPDATE NearbyBSSID SET SSID = '{0}', Level = {1}, Frequency = {2}, Cabilities = '{3}', TimeUpdated = '{4}' WHERE [BSSID] like '{5}';", 
				item.SSID, item.Level, item.Frequency, item.Cabilities, item.TimeUpdated, item.BSSID)
			);
		}

		//NEARGBY
		public Task<List<NearbyBSSID>> GetNearbyBSSID()
		{
			return database.Table<NearbyBSSID>().ToListAsync();
		}

		public Task<List<NearbyBSSID>> WifiWithLocatie()
		{
			//return database.QueryAsync<NearbyBSSID>("SELECT W.BSSID, W.Level, W.Frequency FROM NearbyBSSID W INNER JOIN LocationDB L ON W.IDbssid = L.idBSSID ORDER BY W.Level;");
			//return database.QueryAsync<NearbyBSSID>("SELECT Level FROM [NearbyBSSID]");// WHERE [BSSID] like '" + bssid + "';");

			return database.QueryAsync<NearbyBSSID>("SELECT * FROM [NearbyBSSID] ORDER BY Level DESC");			
			
		}

		public Task<int> CountWifiWithLocatie()
		{
			//return database.QueryAsync<NearbyBSSID>("SELECT W.BSSID, W.Level, W.Frequency FROM NearbyBSSID W INNER JOIN LocationDB L ON W.IDbssid = L.idBSSID ORDER BY W.Level;");
			//return database.QueryAsync<NearbyBSSID>("SELECT Level FROM [NearbyBSSID]");// WHERE [BSSID] like '" + bssid + "';");
			return database.Table<NearbyBSSID>().Take(1).CountAsync();
			
		}

		public Task<List<NearbyBSSID>> GetSavedBSSIDLevel(int level)
		{
			return database.QueryAsync<NearbyBSSID>(string.Format("SELECT level FROM [NearbyBSSID] WHERE [BSSID] like '{0}' LIMIT 1", level));
		}

		public Task<List<NearbyBSSID>> CheckIfBSSIDIsAlreadySavedAndHasLevel(string bssid)
		{
			return database.QueryAsync<NearbyBSSID>("SELECT Level FROM [NearbyBSSID] WHERE [BSSID] like '" + bssid + "';");
		}

		//network
		public Task<int> saveGPS(LocationDB item)
		{
			if (item.IDlocation != 0)
			{
				return database.UpdateAsync(item);
			}
			return database.InsertAsync(item);
		}

		public Task<List<LocationDB>> UpdateGPS(LocationDB item)
		{

			return database.QueryAsync<LocationDB>(string.Format(
				" UPDATE LocationDB SET Latitude = '{0}', Longitude = '{1}', Accuracy = '{2}' WHERE [idBSSID] = '{3}';",
				item.Latitude, item.Longitude, item.Accuracy, item.idBSSID)
			);
		}

	}
}	