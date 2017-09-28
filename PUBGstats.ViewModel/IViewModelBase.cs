using System.ComponentModel;
using System.Windows;

namespace PUBGstats.ViewModel
{
  public interface IViewModelBase : INotifyPropertyChanged, IWeakEventListener
  {
  }
}
