using System.Threading.Tasks;
using Xamarin.Forms;


namespace SensorenCBS
{
	public interface IViewModelManager
	{
		TViewModel Create<TViewModel>(object args = null) where TViewModel : class, IViewModel;
		Page CreatePage<TViewModel>(object args = null) where TViewModel : class, IViewModel;
		Task Push<TViewModel>(object args = null) where TViewModel : class, IViewModel;
		Task Pop();
	}
}
