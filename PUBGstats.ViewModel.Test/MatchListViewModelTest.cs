using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace PUBGstats.ViewModel.Test
{
  public class MatchListViewModelTest
  {
    [Test]
    public void TestGetMatchesIsNullByDefault()
    {
      var sut = new MatchListViewModel(new Mock<IImportMatchesViewModel>().Object);
      Assert.Null(sut.Matches);
    }
  }
}
