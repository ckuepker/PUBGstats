using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace PUBGstats.ViewModel.Test
{
  public class MainWindowViewModelTest
  {
    [Test]
    public void TestGetTabs()
    {
      IMainWindowViewModel sut = new MainWindowViewModel();
      Assert.AreEqual(6, sut.Tabs.Count());
      CollectionAssert.AreEqual(new List<string>
      {
        "Solo FPP","Duo FPP","Squad FPP","Solo TPP","Duo TPP","Squad TPP"
      }, sut.Tabs.Select(t => t.Header));
      CollectionAssert.AllItemsAreInstancesOfType(sut.Tabs.Select(t => t.Content), typeof(IMatchListViewModel));
    }
  }
}
