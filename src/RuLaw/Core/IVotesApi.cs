namespace RuLaw;

/// <summary>
///   <para>Represents an API caller regarding operations of searching for votes/votings.</para>
/// </summary>
public interface IVotesApi
{
  /// <summary>
  ///   <para>Performs search through open results of Duma's voting sessions.</para>
  /// </summary>
  /// <param name="request">Parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Votes search result.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-golosovaniy"/>
  Task<IVotesSearchResult> SearchAsync(IVotesSearchApiRequest request, CancellationToken cancellation = default);
}