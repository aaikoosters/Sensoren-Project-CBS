﻿using System;
using System.IO;
using Xamarin.Forms;
using SensorenCBS.Droid;

[assembly: Dependency(typeof(FileHelper))]
namespace SensorenCBS.Droid
{
	public class FileHelper : IFileHelperDatabase
	{
		public string GetLocalFilePath(string filename)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return Path.Combine(path, filename);
		}
	}
}