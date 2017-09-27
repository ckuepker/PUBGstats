using System;
using PUBGstats.Match;

namespace PUBGstats.Match
{
  public class Match : IMatch
  {
    public Match(int id, GameMode mode, GamePerspective perspective, int kills, int score, int rank, DateTime? date, string deathCause = "", string lesson = "")
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
    }

    public DateTime? Date { get; }
    public int Id { get; }
    public int Kills { get; }
    public int Rank { get; }
    public int Score { get; }
    public string DeathCause { get; }
    public GameMode Mode { get; }
    public GamePerspective Perspective { get; }
    public string Lesson { get; }
  }
}