using System;
using NUnit.Framework;
using PUBGstats.Match;

namespace PUBGstats.Match.IO.Test
{
  public class CsvImporterTest
  {
    [Test]
    public void TestCreatesMatchFromValidLine()
    {
      string csvInput = "1,,,0,100,,,\"0,00\",\"100,00\",AFK,";
      var sut = new CsvImporter(GameMode.Duo, GamePerspective.FPP);
      IMatch m = sut.Import(csvInput);
      Assert.Null(m.Date);
      Assert.AreEqual(GameMode.Duo, m.Mode);
      Assert.AreEqual(GamePerspective.FPP, m.Perspective);
      Assert.AreEqual(1, m.Id);
      Assert.AreEqual(0, m.Kills);
      Assert.AreEqual(100, m.Rank);
      Assert.AreEqual(0, m.Score);
      Assert.AreEqual("AFK", m.DeathCause);
      Assert.AreEqual(string.Empty, m.Lesson);
    }

    [Test]
    public void TestCreatesMatchFromLineWithDate()
    {
      string input = ",170917,,0,24,91,,,,,";
      var sut = new CsvImporter(GameMode.Solo, GamePerspective.FPP);
      IMatch m = sut.Import(input);
      Assert.NotNull(m.Date);
      Assert.AreEqual(new DateTime(2017,09,17), m.Date);
    }

    [Test]
    public void TestCreatesMatchFromLineWithRating()
    {
      string input = ",,,2,26,166,,,,,";
      var  sut = new CsvImporter(GameMode.Solo, GamePerspective.FPP);
      var m = sut.Import(input);
      Assert.AreEqual(1448, m.Rating);
    }

    [Test]
    public void TestCreatesMatchFromLineWithScore()
    {
      string input = ",,,2,26,166,,,,,";
      var sut = new CsvImporter(GameMode.Solo, GamePerspective.FPP);
      var m = sut.Import(input);
      Assert.AreEqual(166, m.Score);
    }
  }
}
