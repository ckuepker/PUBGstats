using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBGstats.Match.IO.Batch
{
  interface IBatchMatchImporter<T>
  {
    IEnumerable<IMatch> Import(T source);
  }
}
