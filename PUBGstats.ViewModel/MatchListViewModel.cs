using System.Collections.Generic;
using PUBGstats.Match;

namespace PUBGstats.ViewModel
{
  public class MatchListViewModel : ViewModelBase, IMatchListViewModel
  {
    private IList<IMatch> _matches;

    public MatchListViewModel(GameMode mode, GamePerspective perspective)
    {
      Mode = mode;
      Perspective = perspective;
    }

    public IList<IMatch> Matches
    {
      get
      {
        return _matches;
      }
      set
      {
        _matches = value;
        OnPropertyChanged("Matches");
      }
    }

    public GameMode Mode { get; }
    public GamePerspective Perspective { get; }
  }
}
