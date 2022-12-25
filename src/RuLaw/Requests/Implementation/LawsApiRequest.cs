namespace RuLaw;

internal sealed class LawsApiRequest : ApiRequest, ILawsApiRequest
{
  public ILawsApiRequest Page(int? page)
  {
    Parameters["page"] = page;

    return this;
  }

  public ILawsApiRequest PageSize(PageSize? size)
  {
    Parameters["limit"] = (int?) size;

    return this;
  }

  public ILawsApiRequest Name(string? name)
  {
    Parameters["name"] = name;

    return this;
  }

  public ILawsApiRequest Type(int? type)
  {
    Parameters["law_type"] = type;

    return this;
  }

  public ILawsApiRequest Topic(long? id)
  {
    Parameters["topic"] = id;

    return this;
  }

  public ILawsApiRequest Number(string? number)
  {
    Parameters["number"] = number;

    return this;
  }

  public ILawsApiRequest DocumentNumber(string? number)
  {
    Parameters["document_number"] = number;

    return this;
  }

  public ILawsApiRequest Status(int? status)
  {
    Parameters["status"] = status;

    return this;
  }

  public ILawsApiRequest Branch(long? id)
  {
    Parameters["class"] = id;

    return this;
  }

  public ILawsApiRequest RegistrationStart(DateTimeOffset? date)
  {
    Parameters["registration_start"] = date?.AsString();

    return this;
  }

  public ILawsApiRequest RegistrationEnd(DateTimeOffset? date)
  {
    Parameters["registration_end"] = date?.AsString();

    return this;
  }

  public ILawsApiRequest Deputy(long? id)
  {
    Parameters["deputy"] = id;

    return this;
  }

  public ILawsApiRequest FederalAuthority(long? id)
  {
    Parameters["federal_subject"] = id;

    return this;
  }

  public ILawsApiRequest RegionalAuthority(long? id)
  {
    Parameters["regional_subject"] = id;

    return this;
  }

  public ILawsApiRequest ProfileCommittee(long? id)
  {
    Parameters["profile_committee"] = id;

    return this;
  }

  public ILawsApiRequest ResponsibleCommittee(long? id)
  {
    Parameters["responsible_committee"] = id;

    return this;
  }

  public ILawsApiRequest SoExecutorCommittee(long? id)
  {
    Parameters["soexecutor_committee"] = id;

    return this;
  }

  public ILawsApiRequest Sorting(string? sort)
  {
    Parameters["sort"] = sort;

    return this;
  }

  public ILawsApiRequest EventsSearchMode(int? mode)
  {
    Parameters["search_mode"] = mode;

    return this;
  }
}