using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PUBGstats.Match.IO.Store;

namespace PUBGstats.Match.IO.Test.Store
{
  public class MatchDataStoreTest
  {
    [Test]
    [TestCase(SeasonType.EA, 4, GameMode.Solo, GamePerspective.FPP, 20)]
    public void TestLoadMatches(SeasonType seasonType, int seasonNumber, GameMode mode, GamePerspective perspective, int expectedMatchCount)
    {
      IMatchDataStore sut = new MatchDataStore();
      IEnumerable<IMatch> matches = sut.LoadMatches(new SeasonInfo(seasonType, seasonNumber), mode, perspective);
      Assert.AreEqual(expectedMatchCount, matches.Count());
      Assert.True(matches.All(m => m.Mode == mode));
      Assert.True(matches.All(m => m.Perspective == perspective));
      Assert.True(matches.All(m => m.Season == new SeasonInfo(seasonType, seasonNumber)));
    }

    [Test]
    public void TestStoreMatches()
    {
      throw new NotImplementedException();
    }
  }
}
