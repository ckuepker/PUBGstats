using System;
using System.Collections.Generic;
using System.IO;

namespace PUBGstats.Match.IO.Batch
{
  public class CsvFileBatchMatchImporter : IBatchMatchImporter<string>
  {
    private readonly GameMode _mode;
    private readonly GamePerspective _perspective;

    public CsvFileBatchMatchImporter(GameMode mode, GamePerspective perspective)
    {
      _mode = mode;
      _perspective = perspective;
    }

    public IEnumerable<IMatch> Import(string source)
    {
      IMatchImporter<string> importer = new CsvImporter(_mode, _perspective);
      IList<IMatch> matches = new List<IMatch>();
      using (StreamReader fileReader = new StreamReader(source))
      {
        string line;
        while ((line = fileReader.ReadLine()) != null)
        {
          var match = importer.Import(line);
          if (match != null)
          {
            matches.Add(match);
          }
        }
        fileReader.Close();
      }
      return matches;
    }
  }
}