namespace PUBGstats.Match
{
  public class SeasonInfo
  {
    public SeasonInfo(SeasonType type, int number)
    {
      Type = type;
      Number = number;
    }

    public SeasonType Type { get; }
    public int Number { get; }

    public override string ToString()
    {
      return string.Format("{0}S{1:D2}", Type == SeasonType.EA ? "Early Access " : "", Number);
    }
  }
}