using System.Collections.Generic;

namespace RuLaw
{
  public abstract class LawApiCall : ILawApiCall
  {
    private readonly IDictionary<string, object> parameters = new Dictionary<string, object>();

    public IDictionary<string, object> Parameters
    {
      get { return this.parameters; }
    }
  }
}