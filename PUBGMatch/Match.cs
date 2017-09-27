using PUBGstats.Match;

namespace PUBGstats.Match
{
  public class Match : IMatch
  {
    public Match(GameMode mode, GamePerspective perspective, int kills, int score, int rank, string deathCause)
    {
      Mode = mode;
      Perspective = perspective;
      Kills = kills;
      Score = score;
      Rank = rank;
      DeathCause = deathCause;
    }

    public int Id { get; }
    public int Kills { get; }
    public int Rank { get; }
    public int Score { get; }
    public string DeathCause { get; }
    public GameMode Mode { get; }
    public GamePerspective Perspective { get; }
  }
}