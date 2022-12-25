namespace RuLaw;

/// <summary>
///   <para>Representation of votes search request to Russian State Duma REST API.</para>
/// </summary>
public interface IVotesSearchApiRequest : IApiRequest
{
  /// <summary>
  ///   <para>Specifies number of law.</para>
  /// </summary>
  /// <param name="number">Number of law.</param>
  /// <returns>Back reference to the current request.</returns>
  IVotesSearchApiRequest Number(string? number);

  /// <summary>
  ///   <para>Specifies identifier of faction.</para>
  /// </summary>
  /// <param name="id">Identifier of faction.</param>
  /// <returns>Back reference to the current request.</returns>
  IVotesSearchApiRequest Faction(long? id);

  /// <summary>
  ///   <para>Specifies identifier of deputy.</para>
  /// </summary>
  /// <param name="id">Identifier of deputy.</param>
  /// <returns>Back reference to the current request.</returns>
  IVotesSearchApiRequest Deputy(long? id);

  /// <summary>
  ///   <para>Specifies identifier of convocation.</para>
  /// </summary>
  /// <param name="id">Identifier of convocation.</param>
  /// <returns>Back reference to the current request.</returns>
  IVotesSearchApiRequest Convocation(long? id);

  /// <summary>
  ///   <para>Specifies lower bound (min) date of convocations.</para>
  /// </summary>
  /// <param name="date">Date of convocations.</param>
  /// <returns>Back reference to the current request.</returns>
  IVotesSearchApiRequest FromDate(DateTimeOffset? date);

  /// <summary>
  ///   <para>Specifies upper bound (max) date of convocations.</para>
  /// </summary>
  /// <param name="date">Date of convocations.</param>
  /// <returns>Back reference to the current request.</returns>
  IVotesSearchApiRequest ToDate(DateTimeOffset? date);

  /// <summary>
  ///   <para>Specifies search keywords.</para>
  /// </summary>
  /// <param name="keywords">Search keywords.</param>
  /// <returns>Back reference to the current request.</returns>
  IVotesSearchApiRequest Keywords(string? keywords);

  /// <summary>
  ///   <para>Specifies number of results page. Equals to 1 by default.</para>
  /// </summary>
  /// <param name="page">Number of results page.</param>
  /// <returns>Back reference to the current request.</returns>
  IVotesSearchApiRequest Page(int? page);

  /// <summary>
  ///   <para>Specifies type of results sorting. Equals to <see cref="VotesSorting.DateDescendingByDay"/> by default.</para>
  /// </summary>
  /// <param name="sorting">Type of sorting.</param>
  /// <returns>Back reference to the current request.</returns>
  IVotesSearchApiRequest Sorting(VotesSorting? sorting);

  /// <summary>
  ///   <para>Specifies number of records per page. Equals to 20 by default.</para>
  /// </summary>
  /// <param name="limit">Size of results page.</param>
  /// <returns>Back reference to the current request.</returns>
  IVotesSearchApiRequest Limit(PageSize? limit);
}