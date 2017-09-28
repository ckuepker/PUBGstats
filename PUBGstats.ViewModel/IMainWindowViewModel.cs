using System.Collections.Generic;

namespace PUBGstats.ViewModel
{
  public interface IMainWindowViewModel
  {
    IViewModelBase AddMatchViewModel { get; }
    string CurrentSeason { get; }
    IImportMatchesViewModel ImportMatchesViewModel { get; }
    IEnumerable<IMatchListViewModel> MatchLists { get; }
    ITabViewModel SelectedContent { get; set; }
    IEnumerable<ITabViewModel> Tabs { get; }
  }
}