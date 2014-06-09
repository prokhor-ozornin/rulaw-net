using System;

namespace RuLaw
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  public interface IVotesSearchLawApiCall : ILawApiCall
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    IVotesSearchLawApiCall Convocation(long id);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    IVotesSearchLawApiCall From(DateTime date);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    IVotesSearchLawApiCall To(DateTime date);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    IVotesSearchLawApiCall Faction(long id);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    IVotesSearchLawApiCall Deputy(long id);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="number"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="number"/> is <see cref="string.Empty"/> string.</exception>
    IVotesSearchLawApiCall Number(string number);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="keywords"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="keywords"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="keywords"/> is <see cref="string.Empty"/> string.</exception>
    IVotesSearchLawApiCall Keywords(string keywords);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    IVotesSearchLawApiCall Page(int page);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="limit"></param>
    /// <returns></returns>
    IVotesSearchLawApiCall Limit(PageSize limit);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="sorting"></param>
    /// <returns></returns>
    IVotesSearchLawApiCall Sorting(VotesSorting sorting);
  }
}