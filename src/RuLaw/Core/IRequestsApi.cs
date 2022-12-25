namespace RuLaw;

/// <summary>
///   <para></para>
/// </summary>
public interface IRequestsApi
{
  /// <summary>
  ///   <para>Returns list of deputies requests.</para>
  /// </summary>
  /// <param name="cancellation"></param>
  /// <returns>Collection of requests.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/deputatskie-zaprosi"/>
  IAsyncEnumerable<IDeputyRequest> All(CancellationToken cancellation = default);
}