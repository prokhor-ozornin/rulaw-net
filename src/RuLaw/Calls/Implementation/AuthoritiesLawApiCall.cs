namespace RuLaw
{
  internal sealed class AuthoritiesLawApiCall : LawApiCall, IAuthoritiesLawApiCall
  {
    public IAuthoritiesLawApiCall Current(bool current = true)
    {
      Parameters["current"] = current.ToString().ToLowerInvariant();
      return this;
    }
  }
}