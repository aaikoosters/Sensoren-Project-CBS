using System;


namespace SensorenCBS
{
    public interface IAppState
    {
        IObservable<object> WhenBackgrounding();
        IObservable<object> WhenResuming();
    }
}
