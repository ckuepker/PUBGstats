using System;
using PUBGMatch;

namespace PUBGstats.Match.Builder
{
  public class MatchBuilder : IMatchBuilder
  {
    private int _kills, _score, _rank, _rating;
    private Mode _mode = Mode.Solo;
    private Perspective _perspective = Perspective.FPP;

    public IMatch Build()
    {
      return new Match(_mode, _perspective, _kills, _score, _rank);
    }

    public IMatchBuilder WithMode(Mode mode)
    {
      throw new NotImplementedException();
    }

    public IMatchBuilder WithPerspective(Perspective perspective)
    {
      throw new NotImplementedException();
    }

    public IMatchBuilder WithKills(int kills)
    {
      _kills = kills;
      return this;
    }

    public IMatchBuilder WithScore(int score)
    {
      _score = score;
      return this;
    }

    public IMatchBuilder WithRank(int rank)
    {
      _rank = rank;
      return this;
    }

    public IMatchBuilder WithRating(int rating)
    {
      throw new NotImplementedException();
    }
  }
}