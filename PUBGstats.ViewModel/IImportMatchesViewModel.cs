using System.Collections.Generic;
using PUBGstats.Match;
using PUBGstats.ViewModel.Command;

namespace PUBGstats.ViewModel
{
  public interface IImportMatchesViewModel : IViewModelBase
  {
    string InputFilePath { get; set; }
    GameMode Mode { get; }
    GamePerspective Perspective { get; }
    IRelayCommand<object> SelectFileCommand { get; }
    IList<IMatch> ImportedMatches { get; }
  }
}