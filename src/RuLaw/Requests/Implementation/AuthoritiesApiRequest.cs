namespace RuLaw;

internal sealed class AuthoritiesApiRequest : ApiRequest, IAuthoritiesApiRequest
{
  public IAuthoritiesApiRequest Current(bool? current = true)
  {
    WithParameter("current", current?.ToString().ToLowerInvariant());

    return this;
  }
}