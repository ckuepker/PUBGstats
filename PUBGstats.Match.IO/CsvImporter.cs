using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using log4net;
using Microsoft.VisualBasic.FileIO;
using PUBGstats.Match;
using PUBGstats.Match.Builder;

namespace PUBGstats.Match.IO
{
  public class CsvImporter : IMatchImporter<string>
  {
    private readonly GameMode _mode;
    private readonly GamePerspective _perspective;

    private ILog _log = LogManager.GetLogger(typeof(CsvImporter).FullName);

    public CsvImporter(GameMode mode, GamePerspective perspective)
    {
      _mode = mode;
      _perspective = perspective;
    }

    public IMatch Import(string input)
    {
      TextReader r = new StringReader(input);
      TextFieldParser p = new TextFieldParser(r);
      p.Delimiters = new[] {","};
      p.HasFieldsEnclosedInQuotes = true;
      string[] fields = p.ReadFields();
      int id, kills, rank, score, rating;
      if (!int.TryParse(fields[0], out id))
      {
        id = 0;
      }
      if (!int.TryParse(fields[3], out kills))
      {
        kills = 0;
      }
      if (!int.TryParse(fields[4], out rank))
      {
        kills = 0;
      }
      if (!int.TryParse(fields[5], out score))
      {
        kills = 0;
      }
      if (!int.TryParse(fields[6], out rating))
      {
        rating = 0;
      }
      DateTime? date = null;
      date = GetDateTime(fields[1]);
      

      IMatchBuilder mb = new MatchBuilder();

      mb.WithPerspective(_perspective)
        .WithMode(_mode)
        .WithId(id)
        .WithKills(kills)
        .WithRank(rank)
        .WithScore(score)
        .WithDeathCause(fields[9])
        .WithLesson(fields[10])
        .WithDate(date)
        .WithRating(rating);

      return mb.Build();
    }

    private DateTime? GetDateTime(string s)
    {
      int offset = 0;
      int year;
      if (s.Length == 8)
      {
        offset += 2;
        if (!int.TryParse(s.Substring(0, 4), out year))
        {
          _log.Info(string.Format("Cannot extract year from date string: {0}",s));
          return null;
        }
      }
      else if (s.Length == 6)
      {
        if (!int.TryParse(s.Substring(0,2), out year))
        {
          _log.Info(string.Format("Cannot extract year from date string: {0}", s));
          return null;
        }
        year += 2000;
      }
      else
      {
        _log.Info(string.Format("Cannot parse match date from CSV because it is not formatted as [YY]YYMMDD: {0}", s));
        return null;
      }

      int month;
      if (!int.TryParse(s.Substring(offset + 2, 2), out month))
      {
        _log.Info(string.Format("Cannot extract month from date string: {0}", s));
        return null;
      }
      int day;
      if (!int.TryParse(s.Substring(offset + 4, 2), out day))
      {
        _log.Info(string.Format("Cannot extract day from date string: {0}", s));
        return null;
      }

      return new DateTime(year,month,day);
    }
  }
}
