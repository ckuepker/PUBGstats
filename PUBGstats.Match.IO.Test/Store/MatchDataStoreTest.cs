using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using PUBGstats.Match.Builder;
using PUBGstats.Match.IO.Store;

namespace PUBGstats.Match.IO.Test.Store
{
  public class MatchDataStoreTest
  {
    private string _root;
    private DirectoryInfo _testStoresSource;
    private DirectoryInfo _testStoresTarget;

    [OneTimeSetUp]
    public void SetUpFixture()
    {
      _root = TestContext.CurrentContext.TestDirectory + "//TestFiles//";
      _testStoresSource = new DirectoryInfo(_root + "Stores");
      _testStoresTarget = new DirectoryInfo(_root + "teststores");
    }

    [SetUp]
    public void Setup()
    {
      Directory.CreateDirectory(_testStoresTarget.FullName);
      foreach (FileInfo f in _testStoresSource.EnumerateFiles())
      {
        File.Copy(f.FullName, _testStoresTarget.FullName + "//" + f.Name, true);
      }
    }

    [TearDown]
    public void TearDown()
    {
      foreach (FileInfo f in _testStoresTarget.EnumerateFiles())
      {
        File.Delete(f.FullName);
      }
      Directory.Delete(_testStoresTarget.FullName);
    }

    [Test]
    public void TestLoadMatchesFromEmptyStore()
    {
      IMatchDataStore sut = new MatchDataStore(_testStoresTarget.FullName + "//empty.json");
      foreach (int i in new[] { 1, 2, 3, 4 })
      {
        foreach (GameMode mode in Enum.GetValues(typeof(GameMode)))
        {
          foreach (GamePerspective perspective in Enum.GetValues(typeof(GamePerspective)))
          {
            CollectionAssert.IsEmpty(sut.LoadMatches(i, mode, perspective).ToList());
          }
        }
      }
    }

    [Test]
    [TestCase(4, GameMode.Solo, GamePerspective.FPP, 20)]
    public void TestLoadMatches(int seasonNumber, GameMode mode, GamePerspective perspective, int expectedMatchCount)
    {
      IMatchDataStore sut = new MatchDataStore(_testStoresTarget.FullName + "//solofpp.json");
      List<IMatch> matches = sut.LoadMatches(seasonNumber, mode, perspective).ToList();
      Assert.AreEqual(expectedMatchCount, matches.Count);
      Assert.True(matches.All(m => m.Mode == mode));
      Assert.True(matches.All(m => m.Perspective == perspective));
      Assert.True(matches.All(m => m.Season == seasonNumber));
    }

    [Test]
    public void TestStoreMatches()
    {
      string storeFile = _testStoresTarget + "//storetest.json";
      FileAssert.DoesNotExist(storeFile);
      IMatchDataStore sut = new MatchDataStore(storeFile);
      IEnumerable<IMatch> matchesToStore = new List<IMatch> {
        new MatchBuilder().WithKills(1).WithRank(1).WithScore(1).WithId(1).WithMode(GameMode.Solo).WithPerspective(GamePerspective.FPP).Build(),
        new MatchBuilder().WithKills(2).WithRank(2).WithScore(2).WithId(2).WithMode(GameMode.Solo).WithPerspective(GamePerspective.FPP).Build(),
        new MatchBuilder().WithKills(3).WithRank(3).WithScore(3).WithId(3).WithMode(GameMode.Solo).WithPerspective(GamePerspective.FPP).Build()
      };
      sut.StoreMatches(matchesToStore);
      FileAssert.Exists(storeFile);
      FileAssert.AreEqual(new FileInfo(TestContext.CurrentContext.TestDirectory + "//TestFiles/Stores/storetest_assert.json"), new FileInfo(storeFile));
    }
  }
}
