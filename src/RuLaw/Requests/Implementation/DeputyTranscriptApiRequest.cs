namespace RuLaw;

internal sealed class DeputyTranscriptApiRequest : ApiRequest, IDeputyTranscriptApiRequest
{
  public IDeputyTranscriptApiRequest Page(int? page)
  {
    Parameters["page"] = page;

    return this;
  }

  public IDeputyTranscriptApiRequest PageSize(PageSize? size)
  {
    Parameters["limit"] = (int?) size;

    return this;
  }

  public IDeputyTranscriptApiRequest Name(string? name)
  {
    Parameters["name"] = name;

    return this;
  }

  public IDeputyTranscriptApiRequest Deputy(long? id)
  {
    Parameters["deputy"] = id;

    return this;
  }

  public IDeputyTranscriptApiRequest FromDate(DateTimeOffset? from)
  {
    Parameters["dateFrom"] = from?.AsString();

    return this;
  }

  public IDeputyTranscriptApiRequest ToDate(DateTimeOffset? to)
  {
    Parameters["dateTo"] = to?.AsString();

    return this;
  }
}