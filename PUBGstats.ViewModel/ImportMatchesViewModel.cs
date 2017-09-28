using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using log4net;
using PUBGstats.Match;
using PUBGstats.ViewModel.Command;
using Microsoft.Win32;
using PUBGstats.Match.IO.Batch;

namespace PUBGstats.ViewModel
{
  public class ImportMatchesViewModel : ViewModelBase, IImportMatchesViewModel
  {
    private readonly IBatchMatchImporter<string> _importer;
    private readonly Action<IEnumerable<IMatch>> _matchesImportedCallback;
    private IRelayCommand<object> _selectFileCommand;

    private readonly ILog _log = LogManager.GetLogger(typeof(ImportMatchesViewModel).FullName);
    private IList<IMatch> _importedMatches;


    public ImportMatchesViewModel(IBatchMatchImporter<string> importer, Action<IEnumerable<IMatch>> matchesImportedCallback)
    {
      _importer = importer;
      _matchesImportedCallback = matchesImportedCallback;
    }

    public GameMode Mode { get; }
    public GamePerspective Perspective { get; }

    public IRelayCommand<object> SelectFileCommand
    {
      get
      {
        return _selectFileCommand ?? (_selectFileCommand = new RelayCommand<object>(o =>
        {
          OpenFileDialog dialog = new OpenFileDialog();
          dialog.DefaultExt = ".csv";
          bool? result = dialog.ShowDialog();
          if (result != null && result.Value)
          {
            string path = dialog.FileName;
            if (!string.IsNullOrEmpty(path))
            {
              try
              {
                IEnumerable<IMatch> matches = _importer.Import(path);
                _matchesImportedCallback(matches);
              }
              catch (IOException ex)
              {
                _log.Error(string.Format("Failed to import file {0}: {1}", path, ex.Message));
              }
            }
          }
        }, o => true));
      }
    }
  }
}
