using System;
using System.ComponentModel;
using Acr;


namespace SensorenCBS
{

	public interface IViewModel : INotifyPropertyChanged, IViewModelLifecycle
	{
		void Init(object args = null);
	}
}
