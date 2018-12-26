namespace RuLaw
{
  internal sealed class InstancesLawApiCall : LawApiCall, IInstancesLawApiCall
  {
    public IInstancesLawApiCall Current(bool current = true)
    {
      Parameters["current"] = current.ToString().ToLowerInvariant();
      return this;
    }
  }
}