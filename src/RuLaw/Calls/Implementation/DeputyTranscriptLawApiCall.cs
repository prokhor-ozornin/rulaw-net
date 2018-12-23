using System;
using Catharsis.Commons;

namespace RuLaw
{
  internal sealed class DeputyTranscriptLawApiCall : LawApiCall, IDeputyTranscriptLawApiCall
  {
    public IDeputyTranscriptLawApiCall Page(int page)
    {
      this.Parameters["page"] = page;
      return this;
    }

    public IDeputyTranscriptLawApiCall PageSize(PageSize size)
    {
      this.Parameters["limit"] = (int) size;
      return this;
    }

    public IDeputyTranscriptLawApiCall Deputy(long id)
    {
      this.Parameters["deputy"] = id;
      return this;
    }

    public IDeputyTranscriptLawApiCall From(DateTime from)
    {
      this.Parameters["dateFrom"] = from.RuLawDate();
      return this;
    }

    public IDeputyTranscriptLawApiCall Name(string name)
    {
      Assertion.NotEmpty(name);

      this.Parameters["name"] = name;
      return this;
    }

    public IDeputyTranscriptLawApiCall To(DateTime to)
    {
      this.Parameters["dateTo"] = to.RuLawDate();
      return this;
    }
  }
}