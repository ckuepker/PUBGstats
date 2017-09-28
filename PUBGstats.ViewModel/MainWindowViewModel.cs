using System.Windows.Input;
using PUBGstats.ViewModel.Command;

namespace PUBGstats.ViewModel
{
  public class MainWindowViewModel : ViewModelBase
  {
    private IViewModelBase _addMatchViewModel, _matchListViewModel;

    public MainWindowViewModel()
    {
    }

    public IViewModelBase SelectedContent
    {
      get { return _matchListViewModel ?? (_matchListViewModel = new MatchListViewModel()); }
    }

    public string CurrentSeason
    {
      get { return "EA Season 4"; }
    }

    public IViewModelBase AddMatchViewModel
    {
      get { return _addMatchViewModel ?? (_addMatchViewModel = new AddMatchViewModel()); }
    }

  }
}