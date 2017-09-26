using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUBGMatch;

namespace PUBGstats.Match
{
  public interface IMatch
  {
    int Id { get; }
    int Kills { get; }
    int Rank { get; }
    int Score { get; }
    string DeathCause { get; }
    Mode GameMode { get; }
    Perspective GamePerspective { get; }
  }
}
