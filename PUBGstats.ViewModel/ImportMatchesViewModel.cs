using PUBGstats.Match;
using PUBGstats.ViewModel.Command;

namespace PUBGstats.ViewModel
{
  public class ImportMatchesViewModel : ViewModelBase, IImportMatchesViewModel
  {

    public ImportMatchesViewModel()
    {
    }

    public GameMode Mode { get; }
    public GamePerspective Perspective { get; }
    public IRelayCommand<object> ImportCommand { get; }
    public string InputFilePath { get; }
  }
}
