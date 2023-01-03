namespace RuLaw;

internal sealed class QuestionsApiRequest : ApiRequest, IQuestionsApiRequest
{
  public IQuestionsApiRequest Page(int? page)
  {
    WithParameter("page", page);

    return this;
  }

  public IQuestionsApiRequest PageSize(PageSize? size)
  {
    WithParameter("limit", (int?) size);

    return this;
  }

  public IQuestionsApiRequest Name(string name)
  {
    WithParameter("name", name);

    return this;
  }

  public IQuestionsApiRequest FromDate(DateTimeOffset? date)
  {
    WithParameter("dateFrom", date?.AsString());

    return this;
  }

  public IQuestionsApiRequest ToDate(DateTimeOffset? date)
  {
    WithParameter("dateTo", date?.AsString());

    return this;
  }
}