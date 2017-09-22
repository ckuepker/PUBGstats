using System.Windows.Input;
using PUBGstats.ViewModel.Command;

namespace PUBGstats.ViewModel
{
  public class MainWindowViewModel : ViewModelBase
  {
    private ICommand _addMatchCommand;

    public ICommand AddMatchCommand
    {
      get { return _addMatchCommand ?? (_addMatchCommand = new RelayCommand<object>(o =>
      {
        
      }, o =>
      {
        return true;
      })); }
    }

    public IViewModelBase SelectedContent
    {
      get { return null; }
    }

    public string CurrentSeason
    {
      get { return "EA Season 4"; }
    }
  }
}