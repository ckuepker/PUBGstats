using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PUBGstats.Match;

namespace PUBGstats.ViewModel.Test
{
  public class MatchListViewModelTest
  {
    [Test]
    public void TestGetMatchesIsNullByDefault()
    {
      var sut = new MatchListViewModel(GameMode.Solo, GamePerspective.FPP);
      Assert.Null(sut.Matches);
    }
  }
}
