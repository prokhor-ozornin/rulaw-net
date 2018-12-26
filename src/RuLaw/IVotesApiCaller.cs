namespace RuLaw
{
  using System;

  /// <summary>
  ///   <para>Represents an API caller regarding operations of searching for votes/votings.</para>
  /// </summary>
  public interface IVotesApiCaller
  {
    /// <summary>
    ///   <para>Russian State Duma REST API caller instance.</para>
    /// </summary>
    IApiCaller Api { get; }

    /// <summary>
    ///   <para>Performs search through open results of Duma's voting sessions.</para>
    /// </summary>
    /// <param name="convocation">Identifier or convocation.</param>
    /// <param name="from">Lower bound (min) date of convocations.</param>
    /// <param name="to">Upper bound (max) date of convocations.</param>
    /// <param name="faction">Identifier of faction.</param>
    /// <param name="deputy">Identifier of deputy.</param>
    /// <param name="number">Number of law.</param>
    /// <param name="keywords">Search keywords.</param>
    /// <param name="page">Number of page in paged result. Equals to 1 by default.</param>
    /// <param name="limit">Number of records per page. Equals to 20 by default.</param>
    /// <param name="sorting">Votes sorting type.</param>
    /// <returns>Votes search result.</returns>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-golosovaniy"/>
    IVotesSearchResult Search(long? convocation = null, DateTime? from = null, DateTime? to = null, long? faction = null, long? deputy = null, string number = null, string keywords = null, int? page = null, PageSize? limit = null, VotesSorting? sorting = null);
  }
}