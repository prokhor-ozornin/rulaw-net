namespace RuLaw
{
  /// <summary>
  ///   <para>Representation of instances search request to Russian State Duma REST API.</para>
  /// </summary>
  public interface IInstancesLawApiCall : ILawApiCall
  {
    /// <summary>
    ///   <para>Specifies whether to lookup currently active or inactive instances.</para>
    /// </summary>
    /// <param name="current"><c>true</c> to search for active instances, <c>false</c> to search for inactive ones.</param>
    /// <returns>Back reference to the current request.</returns>
    IInstancesLawApiCall Current(bool current = true);
  }
}