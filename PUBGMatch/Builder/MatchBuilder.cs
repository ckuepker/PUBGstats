using System;
using System.Collections.Generic;
using System.Linq;
using PUBGstats.Match;

namespace PUBGstats.Match.Builder
{
  public class MatchBuilder : IMatchBuilder
  {
    private int _kills, _score, _rank;
    private GameMode _mode = GameMode.Solo;
    private GamePerspective _perspective = GamePerspective.FPP;
    private string _cause = null;
    private int _id = -1;
    private string _lesson = null;
    private DateTime? _date = null;
    private int? _season = null;
    private List<string> _partnerNames = null;
    private List<int> _partnerKills = null;
    private int? _rating;

    public IMatch Build()
    {
      List<IPartner> partners = null;
      if (_partnerNames != null && _partnerNames.Any() && _partnerKills != null && _partnerKills.Count == _partnerNames.Count)
      {
        partners = new List<IPartner>(_partnerNames.Count);
        for (int i = 0; i < _partnerNames.Count; i++)
        {
          partners.Insert(i, new Partner(_partnerNames[i], _partnerKills[i]));
        }
      }
      return new Match(_id, _mode, _perspective, _kills, _score, _rank, _date, _rating, _cause, _lesson, _season, partners);
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
      _cause = string.IsNullOrEmpty(cause) ? null : cause;
      return this;
    }

    public IMatchBuilder WithId(int id)
    {
      _id = id;
      return this;
    }

    public IMatchBuilder WithLesson(string lesson)
    {
      _lesson = string.IsNullOrEmpty(lesson) ? null : lesson;
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
          return this;
        }
      }
      else if (date.Length == 6)
      {
        if (!int.TryParse(date.Substring(0, 2), out year))
        {
          return this;
        }
        year += 2000;
      }
      else
      {
        return this;
      }

      int month;
      if (!int.TryParse(date.Substring(offset + 2, 2), out month))
      {
        return this;
      }
      int day;
      if (!int.TryParse(date.Substring(offset + 4, 2), out day))
      {
        return this;
      }

      _date = new DateTime(year, month, day);
      return this;
    }

    public IMatchBuilder WithSeason(int season)
    {
      _season = season;
      return this;
    }

    public IMatchBuilder WithPartner(int partner, string name)
    {
      if (_partnerNames == null)
      {
        _partnerNames = new List<string>(3);
      }
      _partnerNames.Insert(partner, name);
      return this;
    }

    public IMatchBuilder WithPartnerKills(int partner, int kills)
    {
      if (_partnerKills == null)
      {
        _partnerKills = new List<int>(3);
      }
      _partnerKills.Insert(partner, kills);
      return this;
    }
  }
}