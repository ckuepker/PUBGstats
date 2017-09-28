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
    private IRelayCommand<object> _selectFileCommand;
    private string _inputFilePath;

    private readonly ILog _log = LogManager.GetLogger(typeof(ImportMatchesViewModel).FullName);
    private IList<IMatch> _importedMatches;


    public ImportMatchesViewModel(IBatchMatchImporter<string> importer)
    {
      _importer = importer;
    }

    public GameMode Mode { get; }
    public GamePerspective Perspective { get; }

    public IList<IMatch> ImportedMatches
    {
      get { return _importedMatches; }
      private set
      {
        _importedMatches = value;
        OnPropertyChanged("ImportedMatches");
      }
    }

    public IRelayCommand<object> SelectFileCommand
    {
      get
      {
        return _selectFileCommand ?? (_selectFileCommand = new RelayCommand<object>(o =>
        {
          OpenFileDialog dlg = new OpenFileDialog();
          dlg.DefaultExt = ".csv";
          //dlg.InitialDirectory = string.IsNullOrEmpty(InputFilePath)
          //  ? Directory.GetCurrentDirectory()
          //  : new FileInfo(InputFilePath).DirectoryName;
          bool? result = dlg.ShowDialog();
          if (result != null && result.Value)
          {
            InputFilePath = dlg.FileName;
          }
        }, o => true));
      }
    }

    public string InputFilePath
    {
      get { return _inputFilePath; }
      set
      {
        _inputFilePath = value;
        if (!string.IsNullOrEmpty(_inputFilePath))
        {
          try
          {
            ImportedMatches = _importer.Import(_inputFilePath).ToList();
          }
          catch (IOException ex)
          {
            _log.Error(string.Format("Failed to import file {0}: {1}", _inputFilePath, ex.Message));
            ImportedMatches = null;
            _inputFilePath = string.Empty;
          }
        }
      }
    }
  }
}
