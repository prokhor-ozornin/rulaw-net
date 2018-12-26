namespace RuLaw
{
  using System;

  /// <summary>
  ///   <para>Representation of deputies search request to Russian State Duma REST API.</para>
  /// </summary>
  public interface IDeputiesLawApiCall : ILawApiCall
  {
    /// <summary>
    ///   <para>Specifies name of deputies to lookup.</para>
    /// </summary>
    /// <param name="name">Name or name part of deputies.</param>
    /// <returns>Back reference to the current request.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    IDeputiesLawApiCall Name(string name);

    /// <summary>
    ///   <para>Specifies position of deputies to lookup.</para>
    /// </summary>
    /// <param name="position">Position of deputies.</param>
    /// <returns>Back reference to the current request.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="position"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="position"/> is <see cref="string.Empty"/> string.</exception>
    IDeputiesLawApiCall Position(string position);

    /// <summary>
    ///   <para>Specifies whether to lookup currently active or inactive deputies.</para>
    /// </summary>
    /// <param name="current"><c>true</c> to search for active deputies, <c>false</c> to search for inactive ones.</param>
    /// <returns>Back reference to the current request.</returns>
    IDeputiesLawApiCall Current(bool current = true);
  }
}