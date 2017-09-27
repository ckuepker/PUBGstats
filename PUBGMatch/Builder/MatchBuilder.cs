using System;
using PUBGstats.Match;

namespace PUBGstats.Match.Builder
{
  public class MatchBuilder : IMatchBuilder
  {
    private int _kills, _score, _rank, _rating;
    private GameMode _mode = GameMode.Solo;
    private GamePerspective _perspective = GamePerspective.FPP;
    private string _cause = string.Empty;

    public IMatch Build()
    {
      return new Match(_mode, _perspective, _kills, _score, _rank, _cause);
    }

    public IMatchBuilder WithMode(GameMode mode)
    {
      throw new NotImplementedException();
    }

    public IMatchBuilder WithPerspective(GamePerspective perspective)
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

    public IMatchBuilder WithDeathCause(string cause)
    {
      _cause = cause;
      return this;
    }
  }
}