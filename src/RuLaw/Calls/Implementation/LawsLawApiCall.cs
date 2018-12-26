namespace RuLaw
{
  using System;
  using Catharsis.Commons;

  internal sealed class LawsLawApiCall : LawApiCall, ILawsLawApiCall
  {
    public ILawsLawApiCall Branch(long id)
    {
      Parameters["class"] = id;
      return this;
    }

    public ILawsLawApiCall Deputy(long id)
    {
      Parameters["deputy"] = id;
      return this;
    }

    public ILawsLawApiCall DocumentNumber(string number)
    {
      Assertion.NotEmpty(number);

      Parameters["document_number"] = number;
      return this;
    }

    public ILawsLawApiCall FederalAuthority(long id)
    {
      Parameters["federal_subject"] = id;
      return this;
    }

    public ILawsLawApiCall Type(int type)
    {
      Parameters["law_type"] = type;
      return this;
    }

    public ILawsLawApiCall Sorting(string sort)
    {
      Assertion.NotEmpty(sort);

      Parameters["sort"] = sort;
      return this;
    }

    public ILawsLawApiCall Status(int status)
    {
      Parameters["status"] = status;
      return this;
    }

    public ILawsLawApiCall Name(string name)
    {
      Assertion.NotEmpty(name);

      Parameters["name"] = name;
      return this;
    }

    public ILawsLawApiCall Number(string number)
    {
      Assertion.NotEmpty(number);

      Parameters["number"] = number;
      return this;
    }

    public ILawsLawApiCall Page(int page)
    {
      Parameters["page"] = page;
      return this;
    }

    public ILawsLawApiCall PageSize(PageSize size)
    {
      Parameters["limit"] = (int) size;
      return this;
    }

    public ILawsLawApiCall ProfileCommittee(long id)
    {
      Parameters["profile_committee"] = id;
      return this;
    }

    public ILawsLawApiCall RegionalAuthority(long id)
    {
      Parameters["regional_subject"] = id;
      return this;
    }

    public ILawsLawApiCall RegistrationEnd(DateTime date)
    {
      Parameters["registration_end"] = date.RuLawDate();
      return this;
    }

    public ILawsLawApiCall RegistrationStart(DateTime date)
    {
      Parameters["registration_start"] = date.RuLawDate();
      return this;
    }

    public ILawsLawApiCall ResponsibleCommittee(long id)
    {
      Parameters["responsible_committee"] = id;
      return this;
    }

    public ILawsLawApiCall SoExecutorCommittee(long id)
    {
      Parameters["soexecutor_committee"] = id;
      return this;
    }
    
    public ILawsLawApiCall EventsSearchMode(int mode)
    {
      Parameters["search_mode"] = mode;
      return this;
    }

    public ILawsLawApiCall Topic(long id)
    {
      Parameters["topic"] = id;
      return this;
    }
  }
}