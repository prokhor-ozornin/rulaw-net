namespace RuLaw;

internal sealed class AuthoritiesApiRequest : ApiRequest, IAuthoritiesApiRequest
{
  public IAuthoritiesApiRequest Current(bool? current = true)
  {
    Parameters["current"] = current?.ToString().ToLowerInvariant();

    return this;
  }
}