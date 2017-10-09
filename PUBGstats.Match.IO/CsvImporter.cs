using System;
using System.IO;
using log4net;
using Microsoft.VisualBasic.FileIO;
using PUBGstats.Match.Builder;

namespace PUBGstats.Match.IO
{
  public class CsvImporter : IMatchImporter<string>
  {
    private readonly GameMode _mode;
    private readonly GamePerspective _perspective;
    private readonly int _season;
    private readonly Func<IMatchBuilder, string, IMatchBuilder>[] _propertyMap;

    private ILog _log = LogManager.GetLogger(typeof(CsvImporter).FullName);

    public CsvImporter(GameMode mode, GamePerspective perspective, int season, Func<IMatchBuilder, string ,IMatchBuilder>[] propertyMap)
    {
      _mode = mode;
      _perspective = perspective;
      _season = season;
      _propertyMap = propertyMap;
    }

    public IMatch Import(string input)
    {
      TextReader r = new StringReader(input);
      TextFieldParser p = new TextFieldParser(r);
      p.Delimiters = new[] {","};
      p.HasFieldsEnclosedInQuotes = true;
      string[] fields = p.ReadFields();
      if (fields == null || fields.Length != _propertyMap.Length)
      {
        throw new ArgumentException(string.Format("CSV line contains incorrect number of expected fields: Expected {0} but contains {1}", _propertyMap.Length, fields != null ? fields.Length : 0));
      }
      IMatchBuilder builder = new MatchBuilder().WithSeason(_season).WithMode(_mode).WithPerspective(_perspective);
      for (int i = 0; i < fields.Length; i++)
      {
        builder = _propertyMap[i](builder, fields[i]);
      }      
      return builder.Build();
    }
  }
}
