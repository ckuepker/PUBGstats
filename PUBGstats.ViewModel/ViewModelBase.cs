using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PUBGstats.ViewModel
{
  public abstract class ViewModelBase : IViewModelBase
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
    {
      if (managerType == typeof(PropertyChangedEventManager))
      {
        ReceivePropertyChanged(sender, (PropertyChangedEventArgs)e);
      }
      else if (managerType == typeof(CollectionChangedEventManager))
      {
        ReceiveCollectionChanged(sender, (NotifyCollectionChangedEventArgs)e);
      }
      else
      {
        throw new ArgumentException(string.Format("Invalid managerType: {0}", managerType.FullName));
      }
      return true;
    }

    protected virtual void ReceiveCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
    {
      // NOOP
    }

    protected virtual void ReceivePropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
    {
      // NOOP
    }
  }
}