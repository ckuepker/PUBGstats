using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PUBGstats.ViewModel
{
  public class ViewModelBase : IViewModelBase
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}