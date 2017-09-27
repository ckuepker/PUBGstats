using System.Collections.Generic;
using System.Windows.Input;
using PUBGstats.ViewModel.Command;
using PUBGstats.Match;
namespace PUBGstats.ViewModel
{
  public class AddMatchViewModel : ViewModelBase
  {
    private ICommand _storeCommand;

    public AddMatchViewModel()
    {
      Mode = GameMode.Squad;
      Perspective = GamePerspective.FPP;
    }

    public ICommand StoreCommand
    {
      get { return _storeCommand ?? (_storeCommand = new RelayCommand<AddMatchViewModel>(m =>
      {
        
      }, m =>
      {
        return !string.IsNullOrEmpty(KillCount) && !string.IsNullOrEmpty(Rank) && !string.IsNullOrEmpty(Score);
      })); }
    }

    public GameMode Mode { get; set; }
    public GamePerspective Perspective { get; set; }
    public string KillCount { get; set; }
    public string Rank { get; set; }
    public string Score { get; set; }

    public IEnumerable<GameMode> AvailableModes
    {
      get { return new List<GameMode> {GameMode.Solo, GameMode.Duo, GameMode.Squad, GameMode.Custom}; }
    }

    public IEnumerable<GamePerspective> AvailablePerspectives
    {
      get { return new List<GamePerspective> { GamePerspective.FPP, GamePerspective.TPP }; }
    }
  }
}