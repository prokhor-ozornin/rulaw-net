namespace RuLaw;

internal sealed class InstancesApiRequest : ApiRequest, IInstancesApiRequest
{
  public IInstancesApiRequest Current(bool? current = true)
  {
    WithParameter("current", current?.ToString().ToLowerInvariant());

    return this;
  }
}