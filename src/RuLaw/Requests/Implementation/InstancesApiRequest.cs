namespace RuLaw;

internal sealed class InstancesApiRequest : ApiRequest, IInstancesApiRequest
{
  public IInstancesApiRequest Current(bool? current = true)
  {
    Parameters["current"] = current?.ToString().ToLowerInvariant();

    return this;
  }
}