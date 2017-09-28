using System.Windows.Input;
using PUBGstats.Match;
using PUBGstats.Match.IO.Batch;
using PUBGstats.ViewModel.Command;

namespace PUBGstats.ViewModel
{
  public class MainWindowViewModel : ViewModelBase
  {
    private IViewModelBase _addMatchViewModel, _matchListViewModel;

    public MainWindowViewModel()
    {
      ImportMatchesViewModel = new ImportMatchesViewModel(new CsvFileBatchMatchImporter(GameMode.Solo, GamePerspective.FPP));
    }

    public IViewModelBase SelectedContent
    {
      get { return _matchListViewModel ?? (_matchListViewModel = new MatchListViewModel(ImportMatchesViewModel)); }
    }

    public string CurrentSeason
    {
      get { return "EA Season 4"; }
    }

    public IViewModelBase AddMatchViewModel
    {
      get { return _addMatchViewModel ?? (_addMatchViewModel = new AddMatchViewModel()); }
    }
    public IImportMatchesViewModel ImportMatchesViewModel { get; }

  }
}