using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUBGstats.Match;

namespace PUBGstats.Match.Builder
{
  public interface IMatchBuilder
  {
    IMatch Build();
    IMatchBuilder WithMode(GameMode mode);
    IMatchBuilder WithPerspective(GamePerspective perspective);
    IMatchBuilder WithKills(int kills);
    IMatchBuilder WithScore(int score);
    IMatchBuilder WithRank(int rank);
    IMatchBuilder WithRating(int rating);
    IMatchBuilder WithDeathCause(string cause);
  }
}
