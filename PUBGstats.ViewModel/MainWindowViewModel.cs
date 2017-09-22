using System.Windows.Input;
using PUBGstats.ViewModel.Command;

namespace PUBGstats.ViewModel
{
  public class MainWindowViewModel : ViewModelBase
  {
    private IViewModelBase _addMatchViewModel;

    public MainWindowViewModel()
    {
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

  }
}