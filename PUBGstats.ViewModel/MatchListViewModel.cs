using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUBGstats.Match;
using PUBGstats.Match.Builder;

namespace PUBGstats.ViewModel
{
  public class MatchListViewModel : ViewModelBase, IMatchListViewModel
  {
    private IList<IMatch> _matches;

    public IList<IMatch> Matches
    {
      get {
        return _matches ?? (_matches = new List<IMatch> {
          new MatchBuilder().WithId(1).WithKills(8).WithRank(2).WithScore(100).Build(),
          new MatchBuilder().WithId(2).WithKills(1).WithRank(22).WithScore(70).Build(),
          new MatchBuilder().WithId(3).WithKills(1).WithRank(65).WithScore(35).Build()
        });
      }
      set { _matches = value; }
    }
  }
}
