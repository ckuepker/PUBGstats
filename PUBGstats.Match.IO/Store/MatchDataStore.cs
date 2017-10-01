using System;
using System.Collections.Generic;

namespace PUBGstats.Match.IO.Store
{
  public class MatchDataStore : IMatchDataStore
  {
    private string _storePath = "";

    public IEnumerable<IMatch> LoadMatches(SeasonInfo seasonInfo, GameMode mode, GamePerspective perspective)
    {
      throw new NotImplementedException();
    }
  }
}