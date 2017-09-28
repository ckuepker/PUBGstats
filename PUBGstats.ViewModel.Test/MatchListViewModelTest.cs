using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace PUBGstats.ViewModel.Test
{
  public class MatchListViewModelTest
  {
    [Test]
    public void TestHasTestMatches()
    {
      IMatchListViewModel sut = new MatchListViewModel();
      Assert.AreEqual(3, sut.Matches.Count);
      for (int i = 0; i < 3; i++)
      {
        Assert.AreEqual(i + 1, sut.Matches[i].Id);
        Assert.AreNotEqual(0, sut.Matches[i].Kills);
        Assert.AreNotEqual(0, sut.Matches[i].Rank);
        Assert.AreNotEqual(0, sut.Matches[i].Score);
      }
    }

    [Test]
    public void TestHasNoTestMatchesAfterFeatureComplete()
    {
      var sut = new MatchListViewModel();
      Assert.AreEqual(0, sut.Matches.Count);
    }
  }
}
