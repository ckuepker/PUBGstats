using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBGstats.Match
{
  public interface IMatch
  {
    int Id { get; }
    int Kills { get; }
    int Rank { get; }
    string DeathCause { get; }
  }
}
