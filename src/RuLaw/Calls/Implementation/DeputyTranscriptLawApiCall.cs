namespace RuLaw
{
  using System;
  using Catharsis.Commons;

  internal sealed class DeputyTranscriptLawApiCall : LawApiCall, IDeputyTranscriptLawApiCall
  {
    public IDeputyTranscriptLawApiCall Page(int page)
    {
      Parameters["page"] = page;
      return this;
    }

    public IDeputyTranscriptLawApiCall PageSize(PageSize size)
    {
      Parameters["limit"] = (int) size;
      return this;
    }

    public IDeputyTranscriptLawApiCall Deputy(long id)
    {
      Parameters["deputy"] = id;
      return this;
    }

    public IDeputyTranscriptLawApiCall From(DateTime from)
    {
      Parameters["dateFrom"] = from.RuLawDate();
      return this;
    }

    public IDeputyTranscriptLawApiCall Name(string name)
    {
      Assertion.NotEmpty(name);

      Parameters["name"] = name;
      return this;
    }

    public IDeputyTranscriptLawApiCall To(DateTime to)
    {
      Parameters["dateTo"] = to.RuLawDate();
      return this;
    }
  }
}