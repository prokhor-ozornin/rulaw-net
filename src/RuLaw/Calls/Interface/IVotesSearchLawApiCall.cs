namespace RuLaw
{
  using System;

  /// <summary>
  ///   <para>Representation of votes search request to Russian State Duma REST API.</para>
  /// </summary>
  public interface IVotesSearchLawApiCall : ILawApiCall
  {
    /// <summary>
    ///   <para>Specifies identifier of convocation.</para>
    /// </summary>
    /// <param name="id">Identifier of convocation.</param>
    /// <returns>Back reference to the current request.</returns>
    IVotesSearchLawApiCall Convocation(long id);

    /// <summary>
    ///   <para>Specifies lower bound (min) date of convocations.</para>
    /// </summary>
    /// <param name="date">Date of convocations.</param>
    /// <returns>Back reference to the current request.</returns>
    IVotesSearchLawApiCall From(DateTime date);

    /// <summary>
    ///   <para>Specifies upper bound (max) date of convocations.</para>
    /// </summary>
    /// <param name="date">Date of convocations.</param>
    /// <returns>Back reference to the current request.</returns>
    IVotesSearchLawApiCall To(DateTime date);

    /// <summary>
    ///   <para>Specifies identifier of faction.</para>
    /// </summary>
    /// <param name="id">Identifier of faction.</param>
    /// <returns>Back reference to the current request.</returns>
    IVotesSearchLawApiCall Faction(long id);

    /// <summary>
    ///   <para>Specifies identifier of deputy.</para>
    /// </summary>
    /// <param name="id">Identifier of deputy.</param>
    /// <returns>Back reference to the current request.</returns>
    IVotesSearchLawApiCall Deputy(long id);

    /// <summary>
    ///   <para>Specifies number of law.</para>
    /// </summary>
    /// <param name="number">Number of law.</param>
    /// <returns>Back reference to the current request.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="number"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="number"/> is <see cref="string.Empty"/> string.</exception>
    IVotesSearchLawApiCall Number(string number);

    /// <summary>
    ///   <para>Specifies search keywords.</para>
    /// </summary>
    /// <param name="keywords">Search keywords.</param>
    /// <returns>Back reference to the current request.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="keywords"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="keywords"/> is <see cref="string.Empty"/> string.</exception>
    IVotesSearchLawApiCall Keywords(string keywords);

    /// <summary>
    ///   <para>Specifies number of results page. Equals to 1 by default.</para>
    /// </summary>
    /// <param name="page">Number of results page.</param>
    /// <returns>Back reference to the current request.</returns>
    IVotesSearchLawApiCall Page(int page);

    /// <summary>
    ///   <para>Specifies number of records per page. Equals to 20 by default.</para>
    /// </summary>
    /// <param name="limit">Size of results page.</param>
    /// <returns>Back reference to the current request.</returns>
    IVotesSearchLawApiCall Limit(PageSize limit);

    /// <summary>
    ///   <para>Specifies type of results sorting. Equals to <see cref="VotesSorting.DateDescendingByDay"/> by default.</para>
    /// </summary>
    /// <param name="sorting">Type of sorting.</param>
    /// <returns>Back reference to the current request.</returns>
    IVotesSearchLawApiCall Sorting(VotesSorting sorting);
  }
}