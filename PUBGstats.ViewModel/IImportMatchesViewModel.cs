using PUBGstats.Match;
using PUBGstats.ViewModel.Command;

namespace PUBGstats.ViewModel
{
  public interface IImportMatchesViewModel : IViewModelBase
  {
    string InputFilePath { get; }
    GameMode Mode { get; }
    GamePerspective Perspective { get; }
    IRelayCommand<object> ImportCommand { get; }
  }
}