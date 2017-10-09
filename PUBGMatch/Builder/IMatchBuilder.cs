using System;

namespace PUBGstats.Match.Builder
{
  public interface IMatchBuilder
  {
    IMatch Build();
    IMatchBuilder WithMode(GameMode mode);
    IMatchBuilder WithPerspective(GamePerspective perspective);
    IMatchBuilder WithKills(int kills);
    IMatchBuilder WithScore(int score);
    IMatchBuilder WithRank(int rank);
    IMatchBuilder WithRating(int rating);
    IMatchBuilder WithDeathCause(string cause);
    IMatchBuilder WithId(int id);
    IMatchBuilder WithLesson(string lesson);
    IMatchBuilder WithDate(DateTime? date);
    IMatchBuilder WithDate(string date);
    IMatchBuilder WithSeason(int season);
    IMatchBuilder WithPartner(int partner, string name);
    IMatchBuilder WithPartnerKills(int partner, int kills);
  }
}
