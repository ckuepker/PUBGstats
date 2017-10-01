using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBGstats.Match.IO.Store
{
  public interface IMatchDataStore
  {
    IEnumerable<IMatch> LoadMatches(SeasonInfo seasonInfo, GameMode mode, GamePerspective perspective);
  }
}
