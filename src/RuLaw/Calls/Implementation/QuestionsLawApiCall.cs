namespace RuLaw
{
  using System;
  using Catharsis.Commons;

  internal sealed class QuestionsLawApiCall : LawApiCall, IQuestionsLawApiCall
  {
    public IQuestionsLawApiCall Page(int page)
    {
      Parameters["page"] = page;
      return this;
    }

    public IQuestionsLawApiCall PageSize(PageSize size)
    {
      Parameters["limit"] = (int) size;
      return this;
    }

    public IQuestionsLawApiCall From(DateTime date)
    {
      Parameters["dateFrom"] = date.RuLawDate();
      return this;
    }

    public IQuestionsLawApiCall Name(string name)
    {
      Assertion.NotEmpty(name);

      Parameters["name"] = name;
      return this;
    }

    public IQuestionsLawApiCall To(DateTime date)
    {
      Parameters["dateTo"] = date.RuLawDate();
      return this;
    }
  }
}