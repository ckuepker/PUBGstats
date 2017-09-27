using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PUBGstats.Match.IO.Batch;

namespace PUBGstats.Match.IO.Test.Batch
{
  public class CsvFileBatchMatchImporterTest
  {
    [Test]
    public void TestImportsSoloFppTestFile()
    {
      var input = TestContext.CurrentContext.TestDirectory + "//TestFiles//solofpp.csv";
      var sut = new CsvFileBatchMatchImporter(GameMode.Solo, GamePerspective.FPP);
      IEnumerable<IMatch> matches = sut.Import(input);
      List<IMatch> matchList = matches.ToList();
      Assert.AreEqual(20, matchList.Count());
      for (int i = 0; i < 20; i++)
      {
        Assert.AreEqual(i+1, matchList[i].Id);
      }
      CollectionAssert.AllItemsAreUnique(matchList);
      Assert.AreEqual(0, matchList.Count(m => m.Kills < 0));
      Assert.AreEqual(0, matchList.Count(m => m.Rank < 0));
      Assert.AreEqual(0, matchList.Count(m => m.Rating < 0));
      Assert.AreEqual(0, matchList.Count(m => m.Score < 0));
      Assert.AreEqual(0, matchList.Count(m => m.Mode != GameMode.Solo));
      Assert.AreEqual(0, matchList.Count(m => m.Perspective != GamePerspective.FPP));
    }
  }
}
