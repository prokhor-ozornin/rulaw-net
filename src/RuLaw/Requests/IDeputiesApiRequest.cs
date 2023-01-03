namespace RuLaw;

/// <summary>
///   <para>Representation of deputies search request to Russian State Duma REST API.</para>
/// </summary>
public interface IDeputiesApiRequest : IApiRequest
{
  /// <summary>
  ///   <para>Specifies name of deputies to lookup.</para>
  /// </summary>
  /// <param name="name">Name or name part of deputies.</param>
  /// <returns>Back reference to the current request.</returns>
  IDeputiesApiRequest Name(string name);

  /// <summary>
  ///   <para>Specifies position of deputies to lookup.</para>
  /// </summary>
  /// <param name="position">Position of deputies.</param>
  /// <returns>Back reference to the current request.</returns>
  IDeputiesApiRequest Position(string position);

  /// <summary>
  ///   <para>Specifies whether to lookup currently active or inactive deputies.</para>
  /// </summary>
  /// <param name="current"><c>true</c> to search for active deputies, <c>false</c> to search for inactive ones.</param>
  /// <returns>Back reference to the current request.</returns>
  IDeputiesApiRequest Current(bool? current = true);
}