namespace RuLaw;

internal sealed class VotesSearchApiRequest : ApiRequest, IVotesSearchApiRequest
{
  public IVotesSearchApiRequest Number(string? number)
  {
    Parameters["number"] = number;

    return this;
  }

  public IVotesSearchApiRequest Faction(long? id)
  {
    Parameters["faction"] = id;

    return this;
  }

  public IVotesSearchApiRequest Deputy(long? id)
  {
    Parameters["deputy"] = id;

    return this;
  }

  public IVotesSearchApiRequest Convocation(long? id)
  {
    Parameters["convocation"] = id;

    return this;
  }

  public IVotesSearchApiRequest FromDate(DateTimeOffset? date)
  {
    Parameters["from"] = date?.AsString();

    return this;
  }

  public IVotesSearchApiRequest ToDate(DateTimeOffset? date)
  {
    Parameters["to"] = date?.AsString();

    return this;
  }

  public IVotesSearchApiRequest Keywords(string? keywords)
  {
    Parameters["keywords"] = keywords;

    return this;
  }

  public IVotesSearchApiRequest Page(int? page)
  {
    Parameters["page"] = page;

    return this;
  }

  public IVotesSearchApiRequest Sorting(VotesSorting? sorting)
  {
    Parameters["sort"] = sorting?.AsString();

    return this;
  }

  public IVotesSearchApiRequest Limit(PageSize? limit)
  {
    Parameters["limit"] = (int?) limit;

    return this;
  }
}