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
      Assert.AreEqual(1, m.Id);
      Assert.AreEqual(0, m.Kills);
      Assert.AreEqual(100, m.Rank);
      Assert.AreEqual("AFK", m.DeathCause);
    }
  }
}
