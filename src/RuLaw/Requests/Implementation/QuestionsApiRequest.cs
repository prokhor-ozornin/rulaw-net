namespace RuLaw;

internal sealed class QuestionsApiRequest : ApiRequest, IQuestionsApiRequest
{
  public IQuestionsApiRequest Page(int? page)
  {
    Parameters["page"] = page;

    return this;
  }

  public IQuestionsApiRequest PageSize(PageSize? size)
  {
    Parameters["limit"] = (int?) size;

    return this;
  }

  public IQuestionsApiRequest Name(string? name)
  {
    Parameters["name"] = name;

    return this;
  }

  public IQuestionsApiRequest FromDate(DateTimeOffset? date)
  {
    Parameters["dateFrom"] = date?.AsString();

    return this;
  }

  public IQuestionsApiRequest ToDate(DateTimeOffset? date)
  {
    Parameters["dateTo"] = date?.AsString();

    return this;
  }
}