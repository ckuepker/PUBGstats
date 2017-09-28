using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUBGstats.Match;
using PUBGstats.Match.Builder;

namespace PUBGstats.ViewModel
{
  public class MatchListViewModel : ViewModelBase, IMatchListViewModel
  {
    private readonly IImportMatchesViewModel _importViewModel;
    private IList<IMatch> _matches;

    public MatchListViewModel(IImportMatchesViewModel importViewModel)
    {
      _importViewModel = importViewModel;
      if (_importViewModel != null)
      {
        PropertyChangedEventManager.AddListener(_importViewModel, this, "ImportedMatches");
      }
    }

    public IList<IMatch> Matches
    {
      get
      {
        return _matches;
      }
      set
      {
        _matches = value;
        OnPropertyChanged("Matches");
      }
    }

    protected override void ReceivePropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
    {
      Matches = _importViewModel.ImportedMatches;
    }
  }
}
