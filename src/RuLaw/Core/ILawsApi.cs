namespace RuLaw;

/// <summary>
///   <para></para>
/// </summary>
public interface ILawsApi
{
  /// <summary>
  ///   <para>Returns list of found laws. Response contains records of laws as well as latest events for each of the law.</para>
  /// </summary>
  /// <param name="request">Parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Laws search result.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-po-zakonoproektam"/>
  Task<ILawsSearchResult> Search(ILawsApiRequest request, CancellationToken cancellation = default);
}