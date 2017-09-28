using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using PUBGstats.Match;
using PUBGstats.Match.IO.Batch;
using PUBGstats.ViewModel.Command;

namespace PUBGstats.ViewModel
{
  public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
  {
    private IViewModelBase _addMatchViewModel, _matchListViewModel;
    private IEnumerable<IMatchListViewModel> _matchLists;

    public MainWindowViewModel()
    {
      ImportMatchesViewModel = new ImportMatchesViewModel(new CsvFileBatchMatchImporter(GameMode.Solo, GamePerspective.FPP),
        matches =>
        {
          if (SelectedContent.Content is IMatchListViewModel)
          {
            ((IMatchListViewModel) SelectedContent.Content).Matches = matches.ToList();
          }
        });
      var tabs = new List<ITabViewModel>();
      foreach (var matchList in MatchLists)
      {
        tabs.Add(new TabViewModel(matchList, string.Format("{0} {1}",matchList.Mode,matchList.Perspective)));
      }
      Tabs = tabs;
      SelectedContent = Tabs.FirstOrDefault();
    }

    public IEnumerable<IMatchListViewModel> MatchLists
    {
      get
      {
        return _matchLists ?? (_matchLists = new List<IMatchListViewModel>
        {
          new MatchListViewModel(GameMode.Solo, GamePerspective.FPP),
          new MatchListViewModel(GameMode.Duo, GamePerspective.FPP),
          new MatchListViewModel(GameMode.Squad, GamePerspective.FPP),
          new MatchListViewModel(GameMode.Solo, GamePerspective.TPP),
          new MatchListViewModel(GameMode.Duo, GamePerspective.TPP),
          new MatchListViewModel(GameMode.Squad, GamePerspective.TPP),
        });
      }
    }

    public IEnumerable<ITabViewModel> Tabs { get; }
    public ITabViewModel SelectedContent { get; set; }

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