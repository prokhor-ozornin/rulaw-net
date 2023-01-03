namespace RuLaw;

/// <summary>
///   <para></para>
/// </summary>
public interface IAuthoritiesApi
{
  /// <summary>
  ///   <para>Returns list of federal law authorities.</para>
  /// </summary>
  /// <param name="request">Additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Collection of authorities.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-federalnih-organov-vlasti"/>
  IAsyncEnumerable<IAuthority> FederalAsync(IAuthoritiesApiRequest request = null, CancellationToken cancellation = default);

  /// <summary>
  ///   <para>Returns list of regional law authorities.</para>
  /// </summary>
  /// <param name="request">Additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Collection of authorities.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-regionalnih-organov-vlasti"/>
  IAsyncEnumerable<IAuthority> RegionalAsync(IAuthoritiesApiRequest request = null, CancellationToken cancellation = default);
}