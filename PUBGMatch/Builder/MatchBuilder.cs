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
    private int? _season = null;

    public IMatch Build()
    {
      return new Match(_id, _mode, _perspective, _kills, _score, _rank, _date, _rating, _cause, _lesson, _season);
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

    public IMatchBuilder WithDate(string date)
    {
      int offset = 0;
      int year;
      if (date.Length == 8)
      {
        offset += 2;
        if (!int.TryParse(date.Substring(0, 4), out year))
        {
          return null;
        }
      }
      else if (date.Length == 6)
      {
        if (!int.TryParse(date.Substring(0, 2), out year))
        {
          return null;
        }
        year += 2000;
      }
      else
      {
        return null;
      }

      int month;
      if (!int.TryParse(date.Substring(offset + 2, 2), out month))
      {
        return null;
      }
      int day;
      if (!int.TryParse(date.Substring(offset + 4, 2), out day))
      {
        return null;
      }

      _date = new DateTime(year, month, day);
      return this;
    }

    public IMatchBuilder WithSeason(int season)
    {
      _season = season;
      return this;
    }
  }
}