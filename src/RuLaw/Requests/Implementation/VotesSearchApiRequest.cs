namespace RuLaw;

internal sealed class VotesSearchApiRequest : ApiRequest, IVotesSearchApiRequest
{
  public IVotesSearchApiRequest Number(string number)
  {
    WithParameter("number", number);

    return this;
  }

  public IVotesSearchApiRequest Faction(long? id)
  {
    WithParameter("faction", id);

    return this;
  }

  public IVotesSearchApiRequest Deputy(long? id)
  {
    WithParameter("deputy", id);

    return this;
  }

  public IVotesSearchApiRequest Convocation(long? id)
  {
    WithParameter("convocation", id);

    return this;
  }

  public IVotesSearchApiRequest FromDate(DateTimeOffset? date)
  {
    WithParameter("from", date?.AsString());

    return this;
  }

  public IVotesSearchApiRequest ToDate(DateTimeOffset? date)
  {
    WithParameter("to", date?.AsString());

    return this;
  }

  public IVotesSearchApiRequest Keywords(string keywords)
  {
    WithParameter("keywords", keywords);

    return this;
  }

  public IVotesSearchApiRequest Page(int? page)
  {
    WithParameter("page", page);

    return this;
  }

  public IVotesSearchApiRequest Sorting(VotesSorting? sorting)
  {
    WithParameter("sort", sorting?.AsString());

    return this;
  }

  public IVotesSearchApiRequest PageSize(PageSize? size)
  {
    WithParameter("limit", (int?) size);

    return this;
  }
}