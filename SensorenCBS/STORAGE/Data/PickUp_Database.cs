﻿using System;
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
			database.CreateTableAsync<Network_ssid>().Wait();
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
			var turning =  database.Table<PickedUp>().CountAsync();
			return turning;
		}

		//network
		public Task<int> SaveItemAsyncNetwork(Network_ssid item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else {
				return database.InsertAsync(item);
			}
		}

		//network
		public Task<int> GetCountedSSID()
		{
			//return databaseAsync.Table<CBS_Tables.PickUpPhone>().CountAsync(); 
			var turning = database.Table<Network_ssid>().CountAsync();
			return turning;
		}
	}
}	