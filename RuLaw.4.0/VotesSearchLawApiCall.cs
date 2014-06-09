using System;
using Catharsis.Commons;

namespace RuLaw
{
  internal sealed class VotesSearchLawApiCall : LawApiCall, IVotesSearchLawApiCall
  {
    public IVotesSearchLawApiCall Convocation(long id)
    {
      this.Parameters["convocation"] = id;
      return this;
    }

    public IVotesSearchLawApiCall From(DateTime date)
    {
      this.Parameters["from"] = date.RuLawDate();
      return this;
    }

    public IVotesSearchLawApiCall To(DateTime date)
    {
      this.Parameters["to"] = date.RuLawDate();
      return this;
    }

    public IVotesSearchLawApiCall Faction(long id)
    {
      this.Parameters["faction"] = id;
      return this;
    }

    public IVotesSearchLawApiCall Deputy(long id)
    {
      this.Parameters["deputy"] = id;
      return this;
    }

    public IVotesSearchLawApiCall Number(string number)
    {
      Assertion.NotEmpty(number);

      this.Parameters["number"] = number;
      return this;
    }

    public IVotesSearchLawApiCall Keywords(string keywords)
    {
      Assertion.NotEmpty(keywords);

      this.Parameters["keywords"] = keywords;
      return this;
    }

    public IVotesSearchLawApiCall Page(int page)
    {
      this.Parameters["page"] = page;
      return this;
    }

    public IVotesSearchLawApiCall Limit(PageSize limit)
    {
      this.Parameters["limit"] = (int) limit;
      return this;
    }

    public IVotesSearchLawApiCall Sorting(VotesSorting sorting)
    {
      this.Parameters["sort"] = sorting.String();
      return this;
    }
  }
}