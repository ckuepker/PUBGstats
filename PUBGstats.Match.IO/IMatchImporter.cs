using System;

namespace PUBGstats.Match.IO
{
  public interface IMatchImporter<T>
  {
    IMatch Import(T input);
  }
}
