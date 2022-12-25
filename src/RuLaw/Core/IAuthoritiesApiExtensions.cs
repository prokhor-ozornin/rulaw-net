using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IAuthoritiesApi"/>.</para>
/// </summary>
/// <seealso cref="IAuthoritiesApi"/>
public static class IAuthoritiesApiExtensions
{
  /// <summary>
  ///   <para>Returns list of federal law authorities.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Collection of authorities.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-federalnih-organov-vlasti"/>
  public static IAsyncEnumerable<IAuthority> Federal(this IAuthoritiesApi api, Action<IAuthoritiesApiRequest>? action = null, CancellationToken cancellation = default)
  {
    var request = new AuthoritiesApiRequest();
    
    action?.Invoke(request);

    return api.Federal(request, cancellation);
  }

  /// <summary>
  ///   <para>Returns list of federal law authorities.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="authorities">Collection of authorities.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns><c>true</c> if call was successful and <paramref name="authorities"/> output parameter contains list of federal authorities, or <c>false</c> if call failed and <paramref name="authorities"/> output parameter is a <c>null</c> reference.</returns>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-federalnih-organov-vlasti"/>
  public static bool Federal(this IAuthoritiesApi api, out IEnumerable<IAuthority>? authorities, Action<IAuthoritiesApiRequest>? action = null, CancellationToken cancellation = default)
  {
    try
    {
      authorities = api.Federal(action, cancellation).ToList(cancellation).Result;
      return true;
    }
    catch
    {
      authorities = null;
      return false;
    }
  }

  /// <summary>
  ///   <para>Returns list of regional law authorities.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Collection of authorities.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-regionalnih-organov-vlasti"/>
  public static IAsyncEnumerable<IAuthority> Regional(this IAuthoritiesApi api, Action<IAuthoritiesApiRequest>? action = null, CancellationToken cancellation = default)
  {
    var request = new AuthoritiesApiRequest();

    action?.Invoke(request);

    return api.Regional(request, cancellation);
  }

  /// <summary>
  ///   <para>Returns list of regional law authorities.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="authorities">Collection of authorities.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns><c>true</c> if call was successful and <paramref name="authorities"/> output parameter contains list of regional authorities, or <c>false</c> if call failed and <paramref name="authorities"/> output parameter is a <c>null</c> reference.</returns>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-regionalnih-organov-vlasti"/>
  public static bool Regional(this IAuthoritiesApi api, out IEnumerable<IAuthority>? authorities, Action<IAuthoritiesApiRequest>? action = null, CancellationToken cancellation = default)
  {
    try
    {
      authorities = api.Federal(action, cancellation).ToList(cancellation).Result;
      return true;
    }
    catch
    {
      authorities = null;
      return false;
    }
  }
}