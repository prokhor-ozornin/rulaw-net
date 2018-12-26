namespace RuLaw
{
  using System;
  using Catharsis.Commons;

  internal sealed class VotesSearchLawApiCall : LawApiCall, IVotesSearchLawApiCall
  {
    public IVotesSearchLawApiCall Convocation(long id)
    {
      Parameters["convocation"] = id;
      return this;
    }

    public IVotesSearchLawApiCall From(DateTime date)
    {
      Parameters["from"] = date.RuLawDate();
      return this;
    }

    public IVotesSearchLawApiCall To(DateTime date)
    {
      Parameters["to"] = date.RuLawDate();
      return this;
    }

    public IVotesSearchLawApiCall Faction(long id)
    {
      Parameters["faction"] = id;
      return this;
    }

    public IVotesSearchLawApiCall Deputy(long id)
    {
      Parameters["deputy"] = id;
      return this;
    }

    public IVotesSearchLawApiCall Number(string number)
    {
      Assertion.NotEmpty(number);

      Parameters["number"] = number;
      return this;
    }

    public IVotesSearchLawApiCall Keywords(string keywords)
    {
      Assertion.NotEmpty(keywords);

      Parameters["keywords"] = keywords;
      return this;
    }

    public IVotesSearchLawApiCall Page(int page)
    {
      Parameters["page"] = page;
      return this;
    }

    public IVotesSearchLawApiCall Limit(PageSize limit)
    {
      Parameters["limit"] = (int) limit;
      return this;
    }

    public IVotesSearchLawApiCall Sorting(VotesSorting sorting)
    {
      Parameters["sort"] = sorting.String();
      return this;
    }
  }
}