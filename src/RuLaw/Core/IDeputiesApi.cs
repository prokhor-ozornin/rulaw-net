namespace RuLaw;

/// <summary>
///   <para></para>
/// </summary>
public interface IDeputiesApi
{
  /// <summary>
  ///   <para>Returns detailed information about specific deputy of the State Duma.</para>
  /// </summary>
  /// <param name="id">Identifier of deputy.</param>
  /// <param name="cancellation"></param>
  /// <returns>Detailed deputy information.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/svedeniya-o-deputate"/>
  Task<IDeputyInfo> FindAsync(long id, CancellationToken cancellation = default);

  /// <summary>
  ///   <para>Returns list of deputies of the State Duma and members of the Federation Council.</para>
  /// </summary>
  /// <param name="request">Additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Collection of deputies.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-deputatov-gd-i-chlenov-sf"/>
  IAsyncEnumerable<IDeputy> SearchAsync(IDeputiesApiRequest request = null, CancellationToken cancellation = default);
}