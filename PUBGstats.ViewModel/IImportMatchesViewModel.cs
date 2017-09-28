using System.Collections.Generic;
using PUBGstats.Match;
using PUBGstats.ViewModel.Command;

namespace PUBGstats.ViewModel
{
  public interface IImportMatchesViewModel : IViewModelBase
  {
    GameMode Mode { get; }
    GamePerspective Perspective { get; }
    IRelayCommand<object> SelectFileCommand { get; }
  }
}