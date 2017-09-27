using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using Microsoft.VisualBasic.FileIO;
using PUBGMatch;

namespace PUBGstats.Match.IO
{
  public class CsvImporter : IMatchImporter<string>
  {
    private readonly Mode _mode;
    private readonly GamePerspective _perspective;
    //private readonly IMatchBuilder _builder;

    public CsvImporter(Mode mode, GamePerspective perspective)
    {
      _mode = mode;
      _perspective = perspective;
    }

    public IMatch Import(string input)
    {
      TextReader r = new StringReader(input);
      TextFieldParser p = new TextFieldParser(r);
      p.HasFieldsEnclosedInQuotes = true;
      string[] fields = p.ReadFields();
      int id = int.Parse(fields[0]);
      return null;

    }

    
  }
}
