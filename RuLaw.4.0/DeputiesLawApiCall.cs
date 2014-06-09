using Catharsis.Commons;

namespace RuLaw
{
  internal sealed class DeputiesLawApiCall : LawApiCall, IDeputiesLawApiCall
  {
    public IDeputiesLawApiCall Name(string name)
    {
      Assertion.NotEmpty(name);

      this.Parameters["begin"] = name;
      return this;
    }

    public IDeputiesLawApiCall Position(string position)
    {
      Assertion.NotEmpty(position);

      this.Parameters["position"] = position;
      return this;
    }

    public IDeputiesLawApiCall Current(bool current = true)
    {
      this.Parameters["current"] = current.ToString().ToLowerInvariant();
      return this;
    }
  }
}