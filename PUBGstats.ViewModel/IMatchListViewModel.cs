using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUBGstats.Match;

namespace PUBGstats.ViewModel
{
  public interface IMatchListViewModel : IViewModelBase
  {
    IList<IMatch> Matches { get; set; }
  }
}
