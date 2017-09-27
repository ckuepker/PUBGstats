using NUnit.Framework;
using PUBGMatch;
using PUBGstats.Match.Builder;

namespace PUBGstats.Match.Test
{
  public class MatchBuilderTest
  {
    [Test]
    public void TestWithMinimalInput()
    {
      var sut = new MatchBuilder();
      var m = sut.WithKills(1).WithRank(47).WithScore(128).Build();
      Assert.AreEqual(Mode.Solo, m.GameMode);
      Assert.AreEqual(GamePerspective.FPP, m.Perspective);
      Assert.AreEqual(1, m.Kills);
      Assert.AreEqual(47, m.Rank);
      Assert.AreEqual(128, m.Score);
    }

    [Test]
    public void TestWithDeathCause()
    {
      var sut = new MatchBuilder();
      var m = sut.WithDeathCause("Player").WithKills(0).WithRank(1).WithScore(1).Build();
      Assert.AreEqual("Player", m.DeathCause);
    }

    [Test]
    public void TestId()
    {
      Assert.Fail("Not implemented");
    }
  }
}
