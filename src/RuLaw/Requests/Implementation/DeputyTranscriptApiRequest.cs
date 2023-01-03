namespace RuLaw;

internal sealed class DeputyTranscriptApiRequest : ApiRequest, IDeputyTranscriptApiRequest
{
  public IDeputyTranscriptApiRequest Page(int? page)
  {
    WithParameter("page", page);

    return this;
  }

  public IDeputyTranscriptApiRequest PageSize(PageSize? size)
  {
    WithParameter("limit", (int?) size);

    return this;
  }

  public IDeputyTranscriptApiRequest Name(string name)
  {
    WithParameter("name", name);

    return this;
  }

  public IDeputyTranscriptApiRequest Deputy(long? id)
  {
    WithParameter("deputy", id);

    return this;
  }

  public IDeputyTranscriptApiRequest FromDate(DateTimeOffset? from)
  {
    WithParameter("dateFrom", from?.AsString());

    return this;
  }

  public IDeputyTranscriptApiRequest ToDate(DateTimeOffset? to)
  {
    WithParameter("dateTo", to?.AsString());

    return this;
  }
}