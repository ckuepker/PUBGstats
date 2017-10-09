using System;
using NUnit.Framework;
using PUBGstats.Match;
using PUBGstats.Match.Builder;

namespace PUBGstats.Match.IO.Test
{
  public class CsvImporterTest
  {
    [Test]
    [TestCase("1,,,0,100,,,\"0,00\",\"100,00\",AFK,", 1, "", 0, 100, null, null, "AFK", null)]
    [TestCase("20,170924,,2,26,166,1448,\"0,68\",\"51,55\",,", 20, "20170924", 2, 26, 166, 1448, null, null)]
    public void TestImportValidSoloS4Line(string csvInput, int id, string date, int kills, int rank, int score, int? rating, string deathCause, string lesson)
    {
      var sut = new CsvImporter(GameMode.Solo, GamePerspective.FPP, 4, new Func<IMatchBuilder, string, IMatchBuilder>[]
      {
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithId(int.Parse(s)),
        (builder, s) => builder.WithDate(s),
        (builder, s) => builder,
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithKills(int.Parse(s)),
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithRank(int.Parse(s)),
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithScore(int.Parse(s)),
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithRating(int.Parse(s)),
        (builder, s) => builder,
        (builder, s) => builder,
        (builder, s) => builder.WithDeathCause(s),
        (builder, s) => builder
      });
      IMatch m = sut.Import(csvInput);
      if (string.IsNullOrEmpty(date))
      {
        Assert.Null(m.Date);
      }
      else
      {
        Assert.True(m.Date.HasValue);
        Assert.AreEqual(date, m.Date.Value.ToString("yyyyMMdd"));
      }
      Assert.AreEqual(GameMode.Solo, m.Mode);
      Assert.AreEqual(GamePerspective.FPP, m.Perspective);
      Assert.AreEqual(4, m.Season);
      Assert.AreEqual(id, m.Id);
      Assert.AreEqual(kills, m.Kills);
      Assert.AreEqual(rank, m.Rank);
      Assert.AreEqual(score, m.Score);
      Assert.AreEqual(rating, m.Rating);
      Assert.AreEqual(deathCause, m.DeathCause);
      Assert.AreEqual(lesson, m.Lesson);
    }

    [Test]
    public void TestImportValidDuoS4Line()
    {
      string csvInput = "1,170923,,Wrensong,2,,4,5,294,1252,\"4,00\",\"5,00\",6,\"6,00\"";
      var sut = new CsvImporter(GameMode.Duo, GamePerspective.FPP, 4, new Func<IMatchBuilder, string, IMatchBuilder>[]
      {
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithId(int.Parse(s)),
        (builder, s) => builder.WithDate(s),
        (builder, s) => builder,
        (builder, s) => builder.WithPartner(0,s),
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithPartnerKills(0,int.Parse(s)),
        (builder, s) => builder,
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithKills(int.Parse(s)),
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithRank(int.Parse(s)),
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithScore(int.Parse(s)),
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithRating(int.Parse(s)),
        (builder, s) => builder,
        (builder, s) => builder,
        (builder, s) => builder,
        (builder, s) => builder
      });
      IMatch m = sut.Import(csvInput);
      Assert.AreEqual(4, m.Season);
      Assert.AreEqual(new DateTime(2017, 9, 23), m.Date);
      Assert.AreEqual(GameMode.Duo, m.Mode);
      Assert.AreEqual(GamePerspective.FPP, m.Perspective);
      Assert.AreEqual(1, m.Id);
      Assert.AreEqual(1, m.Partners.Count);
      Assert.AreEqual("Wrensong", m.Partners[0].Name);
      Assert.AreEqual(2, m.Partners[0].Kills);
      Assert.AreEqual(4, m.Kills);
      Assert.AreEqual(5, m.Rank);
      Assert.AreEqual(294, m.Score);
      Assert.AreEqual(1252, m.Rating);
      Assert.AreEqual(null, m.DeathCause);
      Assert.AreEqual(null, m.Lesson);
    }

    [Test]
    public void TestImportValidSquadS4Line()
    {
      string csvInput = "1,170914,,Wrensong,1,Hsarus,0,,1,20,70,,\"1,00\",\"20,00\",2,\"2,00\"";
      var sut = new CsvImporter(GameMode.Squad, GamePerspective.FPP, 4, new Func<IMatchBuilder, string, IMatchBuilder>[]
      {
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithId(int.Parse(s)),
        (builder, s) => builder.WithDate(s),
        (builder, s) => builder,
        (builder, s) => builder.WithPartner(0,s),
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithPartnerKills(0,int.Parse(s)),
        (builder, s) => builder.WithPartner(1, s),
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithPartnerKills(1, int.Parse(s)),
        (builder, s) => builder,
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithKills(int.Parse(s)),
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithRank(int.Parse(s)),
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithScore(int.Parse(s)),
        (builder, s) => string.IsNullOrEmpty(s) ? builder : builder.WithRating(int.Parse(s)),
        (builder, s) => builder,
        (builder, s) => builder,
        (builder, s) => builder,
        (builder, s) => builder
      });
      IMatch m = sut.Import(csvInput);
      Assert.AreEqual(4, m.Season);
      Assert.AreEqual(new DateTime(2017, 9, 14), m.Date);
      Assert.AreEqual(GameMode.Squad, m.Mode);
      Assert.AreEqual(GamePerspective.FPP, m.Perspective);
      Assert.AreEqual(1, m.Id);
      Assert.AreEqual(2, m.Partners.Count);
      Assert.AreEqual("Wrensong", m.Partners[0].Name);
      Assert.AreEqual(1, m.Partners[0].Kills);
      Assert.AreEqual("Hsarus", m.Partners[1].Name);
      Assert.AreEqual(0, m.Partners[1].Kills);
      Assert.AreEqual(1, m.Kills);
      Assert.AreEqual(20, m.Rank);
      Assert.AreEqual(70, m.Score);
      Assert.AreEqual(null, m.Rating);
      Assert.AreEqual(null, m.DeathCause);
      Assert.AreEqual(null, m.Lesson);
    }

    [Test]
    public void TestImportThrowsExceptionOnInvalidSetup()
    {
      string input = "asdjhskhbjfdbsnfbjndklbn";
      var sut = new CsvImporter(GameMode.Solo, GamePerspective.FPP, 4, new Func<IMatchBuilder, string, IMatchBuilder>[]
      {
        (builder, s) => builder,
        (builder, s) => builder
      });
      Assert.Throws<ArgumentException>(() => sut.Import(input));
    }
  }
}
