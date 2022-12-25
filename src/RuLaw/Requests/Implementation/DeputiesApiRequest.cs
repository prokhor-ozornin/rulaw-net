namespace RuLaw;

internal sealed class DeputiesApiRequest : ApiRequest, IDeputiesApiRequest
{
  public IDeputiesApiRequest Name(string? name)
  {
    Parameters["begin"] = name;

    return this;
  }

  public IDeputiesApiRequest Position(string? position)
  {
    Parameters["position"] = position;

    return this;
  }

  public IDeputiesApiRequest Current(bool? current = true)
  {
    Parameters["current"] = current?.ToString().ToLowerInvariant();

    return this;
  }
}