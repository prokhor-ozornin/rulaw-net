namespace RuLaw
{
  using System.Collections.Generic;

  internal abstract class LawApiCall : ILawApiCall
  {
    private readonly IDictionary<string, object> parameters = new Dictionary<string, object>();

    public IDictionary<string, object> Parameters
    {
      get { return parameters; }
    }
  }
}