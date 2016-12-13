using System;
namespace Droid.SensorenCBS
{
	public class NetworkState
	{
		public virtual bool IsConnected { get; set; }
		public virtual string ConnectionType { get; set; }
	}
}
