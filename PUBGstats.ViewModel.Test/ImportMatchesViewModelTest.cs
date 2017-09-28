using System.Collections.Generic;
using System.IO;
using Moq;
using NUnit.Framework;
using PUBGstats.Match;
using PUBGstats.Match.Builder;
using PUBGstats.Match.IO;
using PUBGstats.Match.IO.Batch;

namespace PUBGstats.ViewModel.Test
{
  public class ImportMatchesViewModelTest
  {
    [Test]
    public void TestSetInputFilePathLoadsMatches()
    {
      var batchImporterMock = new Mock<IBatchMatchImporter<string>>();
      batchImporterMock.Setup(b => b.Import(It.IsAny<string>())).Returns(new List<IMatch> {
        new MatchBuilder().Build(),
        new MatchBuilder().Build()
      }).Verifiable();
      IImportMatchesViewModel sut = new ImportMatchesViewModel(batchImporterMock.Object);
      sut.InputFilePath = TestContext.CurrentContext.WorkDirectory + "//TestFiles//solofpp.csv";
      Assert.AreEqual(2, sut.ImportedMatches.Count);
      batchImporterMock.Verify(b => b.Import(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public void TestInputMatchesIsNullAfterInvalidPath()
    {
      var batchImporterMock = new Mock<IBatchMatchImporter<string>>();
      batchImporterMock.Setup(b => b.Import(It.IsAny<string>())).Throws<IOException>().Verifiable();
      IImportMatchesViewModel sut = new ImportMatchesViewModel(batchImporterMock.Object);
      sut.InputFilePath = "someinvetedpath";
      Assert.Null(sut.ImportedMatches);
      Assert.IsTrue(string.IsNullOrEmpty(sut.InputFilePath));
    }
  }
}
