using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PUBGstats.Match.IO.Store
{
  public class MatchDataStore : IMatchDataStore
  {
    private string _storePath = "";

    public MatchDataStore(string storePath = null)
    {
      _storePath = storePath;
    }

    public IEnumerable<IMatch> LoadMatches(SeasonInfo seasonInfo, GameMode mode, GamePerspective perspective)
    {
      return null;
    }

    public void StoreMatches(IEnumerable<IMatch> matches)
    {
      string json = JsonConvert.SerializeObject(matches);
      Console.WriteLine(json);
      File.WriteAllText(_storePath, json);
    }
  }
}