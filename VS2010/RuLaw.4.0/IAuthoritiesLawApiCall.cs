namespace RuLaw
{
  /// <summary>
  ///   <para>Representation of regional/federal authorities search request to Russian State Duma REST API.</para>
  /// </summary>
  public interface IAuthoritiesLawApiCall : ILawApiCall
  {
    /// <summary>
    ///   <para>Specifies whether to lookup currently active or inactive authorities.</para>
    /// </summary>
    /// <param name="current"><c>true</c> to search for active authorities, <c>false</c> to search for inactive ones.</param>
    /// <returns>Back reference to the current request.</returns>
    IAuthoritiesLawApiCall Current(bool current = true);
  }
}