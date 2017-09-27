using System.Collections.Generic;
using NUnit.Framework;

namespace PUBGstats.ViewModel.Test
{
  public class MatchListViewModelTest
  {
    [Test]
    public void TestHasTestMatches()
    {
      var sut = new MatchListViewModel();
      Assert.AreEqual(3, sut.Matches.Count());
      for (int i = 0; i < 3; i++)
      {
        Assert.AreEqual(i + 1, sut.Matches[i]);
        Assert.AreNotEqual(0, sut.Matches[i].Kills);
        Assert.AreNotEqual(0, sut.Matches[i].Rank);
        Assert.AreNotEqual(0, sut.Matches[i].Score);
      }
    }
  }
}
