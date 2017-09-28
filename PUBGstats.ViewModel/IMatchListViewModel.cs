using System.Collections.Generic;
using PUBGstats.Match;

namespace PUBGstats.ViewModel
{
  public interface IMatchListViewModel : IViewModelBase
  {
    IList<IMatch> Matches { get; set; }
    GameMode Mode { get; }
    GamePerspective Perspective { get; }
  }
}
