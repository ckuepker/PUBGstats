using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUBGstats.Match;

namespace PUBGstats.Match
{
  public interface IMatch
  {
    int Id { get; }
    int Kills { get; }
    int Rank { get; }
    int Score { get; }
    string DeathCause { get; }
    GameMode Mode { get; }
    GamePerspective Perspective { get; }
    string Lesson { get; }
    DateTime? Date { get; }
    int Rating { get; }
  }
}
