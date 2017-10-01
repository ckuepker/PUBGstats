using NUnit.Framework;

namespace PUBGstats.Match.Test
{
  public class SeasonInfoTest
  {
    [Test]
    public void TestToString()
    {
      SeasonInfo sut = new SeasonInfo(SeasonType.EA, 3);
      Assert.AreEqual("Early Access S03", sut.ToString());
    }
  }
}
