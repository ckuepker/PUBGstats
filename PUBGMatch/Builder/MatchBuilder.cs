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
    private int _id = -1;
    private string _lesson = string.Empty;
    private DateTime? _date = null;

    public IMatch Build()
    {
      return new Match(_id, _mode, _perspective, _kills, _score, _rank, _date, _rating, _cause, _lesson);
    }

    public IMatchBuilder WithMode(GameMode mode)
    {
      _mode = mode;
      return this;
    }

    public IMatchBuilder WithPerspective(GamePerspective perspective)
    {
      _perspective = perspective;
      return this;
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
      _rating = rating;
      return this;
    }

    public IMatchBuilder WithDeathCause(string cause)
    {
      _cause = cause;
      return this;
    }

    public IMatchBuilder WithId(int id)
    {
      _id = id;
      return this;
    }

    public IMatchBuilder WithLesson(string lesson)
    {
      _lesson = lesson;
      return this;
    }

    public IMatchBuilder WithDate(DateTime? date)
    {
      _date = date;
      return this;
    }
  }
}