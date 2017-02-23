using System;


namespace SensorenCBS
{
    public interface IAppLifecycle
    {
        void OnForeground();
        void OnBackground();
    }
}
