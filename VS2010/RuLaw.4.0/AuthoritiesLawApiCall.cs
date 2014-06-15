namespace RuLaw
{
  internal sealed class AuthoritiesLawApiCall : LawApiCall, IAuthoritiesLawApiCall
  {
    public IAuthoritiesLawApiCall Current(bool current = true)
    {
      this.Parameters["current"] = current.ToString().ToLowerInvariant();
      return this;
    }
  }
}