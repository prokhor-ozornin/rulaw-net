namespace RuLaw;

internal sealed class LawsApiRequest : ApiRequest, ILawsApiRequest
{
  public ILawsApiRequest Page(int? page)
  {
    WithParameter("page", page);

    return this;
  }

  public ILawsApiRequest PageSize(PageSize? size)
  {
    WithParameter("limit", (int?) size);

    return this;
  }

  public ILawsApiRequest Name(string name)
  {
    WithParameter("name", name);

    return this;
  }

  public ILawsApiRequest Type(int? type)
  {
    WithParameter("law_type", type);

    return this;
  }

  public ILawsApiRequest Topic(long? id)
  {
    WithParameter("topic", id);

    return this;
  }

  public ILawsApiRequest Number(string number)
  {
    WithParameter("number", number);

    return this;
  }

  public ILawsApiRequest DocumentNumber(string number)
  {
    WithParameter("document_number", number);

    return this;
  }

  public ILawsApiRequest Status(int? status)
  {
    WithParameter("status", status);

    return this;
  }

  public ILawsApiRequest Branch(long? id)
  {
    WithParameter("class", id);

    return this;
  }

  public ILawsApiRequest RegistrationStart(DateTimeOffset? date)
  {
    WithParameter("registration_start", date?.AsString());

    return this;
  }

  public ILawsApiRequest RegistrationEnd(DateTimeOffset? date)
  {
    WithParameter("registration_end", date?.AsString());

    return this;
  }

  public ILawsApiRequest Deputy(long? id)
  {
    WithParameter("deputy", id);

    return this;
  }

  public ILawsApiRequest FederalAuthority(long? id)
  {
    WithParameter("federal_subject", id);

    return this;
  }

  public ILawsApiRequest RegionalAuthority(long? id)
  {
    WithParameter("regional_subject", id);

    return this;
  }

  public ILawsApiRequest ProfileCommittee(long? id)
  {
    WithParameter("profile_committee", id);

    return this;
  }

  public ILawsApiRequest ResponsibleCommittee(long? id)
  {
    WithParameter("responsible_committee", id);

    return this;
  }

  public ILawsApiRequest SoExecutorCommittee(long? id)
  {
    WithParameter("soexecutor_committee", id);

    return this;
  }

  public ILawsApiRequest Sorting(string sort)
  {
    WithParameter("sort", sort);

    return this;
  }

  public ILawsApiRequest EventsSearchMode(int? mode)
  {
    WithParameter("search_mode", mode);

    return this;
  }
}