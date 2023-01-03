namespace RuLaw;

internal sealed class DeputiesApiRequest : ApiRequest, IDeputiesApiRequest
{
  public IDeputiesApiRequest Name(string name)
  {
    WithParameter("begin", name);

    return this;
  }

  public IDeputiesApiRequest Position(string position)
  {
    WithParameter("position", position);

    return this;
  }

  public IDeputiesApiRequest Current(bool? current = true)
  {
    WithParameter("current", current?.ToString().ToLowerInvariant());

    return this;
  }
}