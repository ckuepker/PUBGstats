using PUBGMatch;

namespace PUBGstats.Match
{
  public class Match : IMatch
  {
    private static int _nextId = 1;

    private Mode _mode;
    private Perspective _perspective;
    private int _kills;
    private int _score;
    private int _rank;

    public Match(Mode mode, Perspective perspective, int kills, int score, int rank)
    {
      GameMode = mode;
      GamePerspective = perspective;
      Id = _nextId++;
      Kills = kills;
      Score = score;
      Rank = rank;
    }

    public int Id { get; }
    public int Kills { get; }
    public int Rank { get; }
    public int Score { get; }
    public string DeathCause { get; }
    public Mode GameMode { get; }
    public Perspective GamePerspective { get; }
  }
}