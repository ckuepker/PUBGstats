using System;
using System.Collections.Generic;
using PUBGstats.Match;

namespace PUBGstats.Match
{
  public class Match : IMatch
  {
    public Match(int id, GameMode mode, GamePerspective perspective, int kills, int score, int rank, DateTime? date = null, int? rating = -1, string deathCause = "", string lesson = "", int? season = null, List<IPartner> partners = null)
    {
      Id = id;
      Mode = mode;
      Perspective = perspective;
      Kills = kills;
      Score = score;
      Rank = rank;
      DeathCause = deathCause;
      Lesson = lesson;
      Date = date;
      Rating = rating;
      Season = season;
      Partners = partners;
    }

    public DateTime? Date { get; }
    public int? Rating { get; }
    public int Id { get; }
    public int Kills { get; }
    public int Rank { get; }
    public int Score { get; }
    public string DeathCause { get; }
    public GameMode Mode { get; }
    public GamePerspective Perspective { get; }
    public string Lesson { get; }
    public int? Season { get; }
    public List<IPartner> Partners { get; }
  }
}