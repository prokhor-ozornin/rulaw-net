namespace RuLaw
{
  using Catharsis.Commons;

  internal sealed class DeputiesLawApiCall : LawApiCall, IDeputiesLawApiCall
  {
    public IDeputiesLawApiCall Name(string name)
    {
      Assertion.NotEmpty(name);

      Parameters["begin"] = name;
      return this;
    }

    public IDeputiesLawApiCall Position(string position)
    {
      Assertion.NotEmpty(position);

      Parameters["position"] = position;
      return this;
    }

    public IDeputiesLawApiCall Current(bool current = true)
    {
      Parameters["current"] = current.ToString().ToLowerInvariant();
      return this;
    }
  }
}