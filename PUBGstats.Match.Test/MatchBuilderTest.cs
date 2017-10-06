using System;
using NUnit.Framework;
using PUBGstats.Match;
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
      Assert.AreEqual(GameMode.Solo, m.Mode);
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
    public void TestWithoutDeathCause()
    {
      var m = GetMinimalBuilder().Build();
      Assert.AreEqual(string.Empty, m.DeathCause);
    }

    [Test]
    public void TestWithId()
    {
      var m = GetMinimalBuilder().WithId(147).Build();
      Assert.AreEqual(147, m.Id);
    }

    [Test]
    public void TestWithoutId()
    {
      var m = GetMinimalBuilder().Build();
      Assert.AreEqual(-1, m.Id);
    }

    [Test]
    public void TestWithPerspective()
    {
      var sut = GetMinimalBuilder(0, 0, 0);
      var m = sut.WithPerspective(GamePerspective.TPP).Build();
      Assert.AreEqual(GamePerspective.TPP, m.Perspective);
    }

    [Test]
    public void TestWithoutPerspective()
    {
      var sut = GetMinimalBuilder(0, 0, 0);
      var m = sut.Build();
      Assert.AreEqual(GamePerspective.FPP, m.Perspective);
    }

    [Test]
    public void TestWithMode()
    {
      var sut = GetMinimalBuilder();
      var m = sut.WithMode(GameMode.Duo).Build();
      Assert.AreEqual(GameMode.Duo, m.Mode);
    }


    [Test]
    public void TestWithoutMode()
    {
      var m = GetMinimalBuilder().Build();
      Assert.AreEqual(GameMode.Solo, m.Mode);
    }

    [Test]
    public void TestWithLesson()
    {
      var m = GetMinimalBuilder().WithLesson("Don't overextend").Build();
      Assert.AreEqual("Don't overextend", m.Lesson);
    }

    [Test]
    public void TestWithoutLesson()
    {
      var m = GetMinimalBuilder().Build();
      Assert.AreEqual(string.Empty, m.Lesson);
    }

    [Test]
    public void TestWithDate()
    {
      var m = GetMinimalBuilder().WithDate(new DateTime(1985, 03, 04)).Build();
      Assert.AreEqual(new DateTime(1985,03,04), m.Date);
    }

    [Test]
    public void TestWithoutDate()
    {
      var m = GetMinimalBuilder().Build();
      Assert.Null(m.Date);
    }

    [Test]
    public void TestWithRating()
    {
      var m = GetMinimalBuilder().WithRating(1411).Build();
      Assert.AreEqual(1411,m.Rating);
    }

    [Test]
    public void TestWithoutRating()
    {
      var m = GetMinimalBuilder().Build();
      Assert.AreEqual(0,m.Rating);
    }

    [Test]
    public void TestWithoutSeason()
    {
      IMatch sut = GetMinimalBuilder().Build();
      Assert.Null(sut.Season);
    }

    [Test]
    public void TestMatchWithSeasono()
    {
      IMatch sut = GetMinimalBuilder().WithSeason(4).Build();
      Assert.AreEqual(4, sut.Season);
    }

    private IMatchBuilder GetMinimalBuilder(int kills = 0, int rank = 0, int score = 0)
    {
      return new MatchBuilder().WithKills(kills).WithRank(rank).WithScore(score);
    }
  }
}
