using PUBGMatch;

namespace PUBGstats.Match
{
  public class Match : IMatch
  {
    private static int _nextId = 1;

    public Match(Mode mode, GamePerspective perspective, int kills, int score, int rank, string deathCause)
    {
      GameMode = mode;
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
    public Mode GameMode { get; }
    public GamePerspective Perspective { get; }
  }
}