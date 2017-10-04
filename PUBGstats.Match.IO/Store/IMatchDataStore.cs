using System.Collections.Generic;

namespace PUBGstats.Match.IO.Store
{
  public interface IMatchDataStore
  {
    IEnumerable<IMatch> LoadMatches(SeasonInfo seasonInfo, GameMode mode, GamePerspective perspective);
    void StoreMatches(IEnumerable<IMatch> matches);
  }
}
