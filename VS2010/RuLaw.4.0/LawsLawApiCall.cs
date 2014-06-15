using System;
using Catharsis.Commons;

namespace RuLaw
{
  internal sealed class LawsLawApiCall : LawApiCall, ILawsLawApiCall
  {
    public ILawsLawApiCall Branch(long id)
    {
      this.Parameters["class"] = id;
      return this;
    }

    public ILawsLawApiCall Deputy(long id)
    {
      this.Parameters["deputy"] = id;
      return this;
    }

    public ILawsLawApiCall DocumentNumber(string number)
    {
      Assertion.NotEmpty(number);

      this.Parameters["document_number"] = number;
      return this;
    }

    public ILawsLawApiCall FederalAuthority(long id)
    {
      this.Parameters["federal_subject"] = id;
      return this;
    }

    public ILawsLawApiCall Type(int type)
    {
      this.Parameters["law_type"] = type;
      return this;
    }

    public ILawsLawApiCall Sorting(string sort)
    {
      Assertion.NotEmpty(sort);

      this.Parameters["sort"] = sort;
      return this;
    }

    public ILawsLawApiCall Status(int status)
    {
      this.Parameters["status"] = status;
      return this;
    }

    public ILawsLawApiCall Name(string name)
    {
      Assertion.NotEmpty(name);

      this.Parameters["name"] = name;
      return this;
    }

    public ILawsLawApiCall Number(string number)
    {
      Assertion.NotEmpty(number);

      this.Parameters["number"] = number;
      return this;
    }

    public ILawsLawApiCall Page(int page)
    {
      this.Parameters["page"] = page;
      return this;
    }

    public ILawsLawApiCall PageSize(PageSize size)
    {
      this.Parameters["limit"] = (int) size;
      return this;
    }

    public ILawsLawApiCall ProfileCommittee(long id)
    {
      this.Parameters["profile_committee"] = id;
      return this;
    }

    public ILawsLawApiCall RegionalAuthority(long id)
    {
      this.Parameters["regional_subject"] = id;
      return this;
    }

    public ILawsLawApiCall RegistrationEnd(DateTime date)
    {
      this.Parameters["registration_end"] = date.RuLawDate();
      return this;
    }

    public ILawsLawApiCall RegistrationStart(DateTime date)
    {
      this.Parameters["registration_start"] = date.RuLawDate();
      return this;
    }

    public ILawsLawApiCall ResponsibleCommittee(long id)
    {
      this.Parameters["responsible_committee"] = id;
      return this;
    }

    public ILawsLawApiCall SoExecutorCommittee(long id)
    {
      this.Parameters["soexecutor_committee"] = id;
      return this;
    }
    
    public ILawsLawApiCall EventsSearchMode(int mode)
    {
      this.Parameters["search_mode"] = mode;
      return this;
    }

    public ILawsLawApiCall Topic(long id)
    {
      this.Parameters["topic"] = id;
      return this;
    }
  }
}