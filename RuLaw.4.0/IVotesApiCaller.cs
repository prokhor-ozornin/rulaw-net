using System;

namespace RuLaw
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  public interface IVotesApiCaller
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    IApiCaller Api { get; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="convocation"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="faction"></param>
    /// <param name="deputy"></param>
    /// <param name="number"></param>
    /// <param name="keywords"></param>
    /// <param name="page"></param>
    /// <param name="limit"></param>
    /// <param name="sorting"></param>
    /// <returns></returns>
    /// <exception cref="RuLawException"></exception>
    VotesSearchResult Search(long? convocation = null, DateTime? from = null, DateTime? to = null, long? faction = null, long? deputy = null, string number = null, string keywords = null, int? page = null, PageSize? limit = null, VotesSorting? sorting = null);
  }
}