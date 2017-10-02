using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
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
      _testStoresSource = new DirectoryInfo(_root+"Stores");
      _testStoresTarget = new DirectoryInfo(_root+"teststores");
    }

    [SetUp]
    public void Setup()
    {
      Directory.CreateDirectory(_testStoresTarget.FullName);
      foreach (FileInfo f in _testStoresSource.EnumerateFiles())
      {
        File.Copy(f.FullName, _testStoresTarget.FullName+"//"+f.Name, true);
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
      IMatchDataStore sut = new MatchDataStore(_testStoresTarget.FullName+"//empty.json");
      foreach (SeasonType seasonType in Enum.GetValues(typeof(SeasonType)))
      {
        foreach (int i in new[] {1, 2, 3, 4})
        {
          SeasonInfo si = new SeasonInfo(seasonType, i);
          foreach (GameMode mode in Enum.GetValues(typeof(GameMode)))
          {
            foreach (GamePerspective perspective in Enum.GetValues(typeof(GamePerspective)))
            {
              CollectionAssert.IsEmpty(sut.LoadMatches(si, mode, perspective).ToList());
            }
          }
        }
      }
    }

    [Test]
    [TestCase(SeasonType.EA, 4, GameMode.Solo, GamePerspective.FPP, 20)]
    public void TestLoadMatches(SeasonType seasonType, int seasonNumber, GameMode mode, GamePerspective perspective, int expectedMatchCount)
    {
      IMatchDataStore sut = new MatchDataStore(_testStoresTarget.FullName+"//solofpp.json");
      List<IMatch> matches = sut.LoadMatches(new SeasonInfo(seasonType, seasonNumber), mode, perspective).ToList();
      Assert.AreEqual(expectedMatchCount, matches.Count);
      Assert.True(matches.All(m => m.Mode == mode));
      Assert.True(matches.All(m => m.Perspective == perspective));
      Assert.True(matches.All(m => m.Season == new SeasonInfo(seasonType, seasonNumber)));
    }

    [Test]
    public void TestStoreMatches()
    {
      throw new NotImplementedException();
    }
  }
}
