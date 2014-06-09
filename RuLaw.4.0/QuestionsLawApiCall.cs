using System;
using Catharsis.Commons;

namespace RuLaw
{
  internal sealed class QuestionsLawApiCall : LawApiCall, IQuestionsLawApiCall
  {
    public IQuestionsLawApiCall Page(int page)
    {
      this.Parameters["page"] = page;
      return this;
    }

    public IQuestionsLawApiCall PageSize(PageSize size)
    {
      this.Parameters["limit"] = (int) size;
      return this;
    }

    public IQuestionsLawApiCall From(DateTime date)
    {
      this.Parameters["dateFrom"] = date.RuLawDate();
      return this;
    }

    public IQuestionsLawApiCall Name(string name)
    {
      Assertion.NotEmpty(name);

      this.Parameters["name"] = name;
      return this;
    }

    public IQuestionsLawApiCall To(DateTime date)
    {
      this.Parameters["dateTo"] = date.RuLawDate();
      return this;
    }
  }
}