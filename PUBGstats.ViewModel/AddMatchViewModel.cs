using System.Collections.Generic;
using System.Windows.Input;
using PUBGMatch;
using PUBGstats.ViewModel.Command;

namespace PUBGstats.ViewModel
{
  public class AddMatchViewModel : ViewModelBase
  {
    private ICommand _storeCommand;

    public AddMatchViewModel()
    {
      GameMode = Mode.Squad;
      Perspective = PUBGMatch.GamePerspective.FPP;
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

    public Mode GameMode { get; set; }
    public GamePerspective Perspective { get; set; }
    public string KillCount { get; set; }
    public string Rank { get; set; }
    public string Score { get; set; }

    public IEnumerable<Mode> AvailableModes
    {
      get { return new List<Mode> {Mode.Solo, Mode.Duo, Mode.Squad, Mode.Custom}; }
    }

    public IEnumerable<GamePerspective> AvailablePerspectives
    {
      get { return new List<GamePerspective> { GamePerspective.FPP, GamePerspective.TPP }; }
    }
  }
}