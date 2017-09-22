using System.Windows.Input;
using PUBGstats.ViewModel.Command;

namespace PUBGstats.ViewModel
{
  public class MainWindowViewModel : ViewModelBase
  {
    private ICommand _addMatchCommand;
    private IViewModelBase _addMatchViewModel;

    public MainWindowViewModel()
    {
      IsAddingMatch = false;
    }

    public ICommand AddMatchCommand
    {
      get { return _addMatchCommand ?? (_addMatchCommand = new RelayCommand<object>(o =>
      {
        IsAddingMatch = true;
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

    public IViewModelBase AddMatchViewModel
    {
      get { return _addMatchViewModel ?? (_addMatchViewModel = new AddMatchViewModel()); }
    }

    public bool IsAddingMatch { get; private set; }
  }
}