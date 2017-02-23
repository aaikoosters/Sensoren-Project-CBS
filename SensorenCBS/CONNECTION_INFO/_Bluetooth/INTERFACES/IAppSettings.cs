using System;
using System.ComponentModel;


namespace SensorenCBS
{
    public interface IAppSettings : INotifyPropertyChanged
    {
        bool EnableBackgroundScan { get; set; }
        Guid BackgroundScanServiceUuid { get; set; }
        //Guid BgScanToConnect

        //bool AreNotificationsEnabled { get; set; }
        bool IsLoggingEnabled { get; set; }
    }
}
