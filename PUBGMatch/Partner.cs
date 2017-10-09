namespace PUBGstats.Match
{
  public class Partner : IPartner
  {
    public Partner(string name, int kills)
    {
      Name = name;
      Kills = kills;
    }

    public string Name { get; }
    public int Kills { get; }
  }
}