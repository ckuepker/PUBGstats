using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBGstats.Match.IO
{
  public interface IMatchImporter<T>
  {
    IMatch Import(T input);
  }
}
