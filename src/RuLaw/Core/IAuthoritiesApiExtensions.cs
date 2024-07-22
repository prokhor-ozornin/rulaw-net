using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IAuthoritiesApi"/> interface.</para>
/// </summary>
/// <seealso cref="IAuthoritiesApi"/>
public static class IAuthoritiesApiExtensions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="api"></param>
  /// <param name="request"></param>
  /// <returns></returns>
  public static IEnumerable<IAuthority> Federal(this IAuthoritiesApi api, IAuthoritiesApiRequest request = null) => api is not null ? api.FederalAsync(request).ToListAsync().Result : throw new ArgumentNullException(nameof(api));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="api"></param>
  /// <param name="action"></param>
  /// <returns></returns>
  public static IEnumerable<IAuthority> Federal(this IAuthoritiesApi api, Action<IAuthoritiesApiRequest> action = null) => api is not null ? api.FederalAsync(action).ToListAsync().Result : throw new ArgumentNullException(nameof(api));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="api"></param>
  /// <param name="request"></param>
  /// <returns></returns>
  public static IEnumerable<IAuthority> Regional(this IAuthoritiesApi api, IAuthoritiesApiRequest request = null) => api is not null ? api.RegionalAsync(request).ToListAsync().Result : throw new ArgumentNullException(nameof(api));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="api"></param>
  /// <param name="action"></param>
  /// <returns></returns>
  public static IEnumerable<IAuthority> Regional(this IAuthoritiesApi api, Action<IAuthoritiesApiRequest> action = null) => api is not null ? api.RegionalAsync(action).ToListAsync().Result : throw new ArgumentNullException(nameof(api));

  /// <summary>
  ///   <para>Returns list of federal law authorities.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Collection of authorities.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-federalnih-organov-vlasti"/>
  public static IAsyncEnumerable<IAuthority> FederalAsync(this IAuthoritiesApi api, Action<IAuthoritiesApiRequest> action = null, CancellationToken cancellation = default)
  {
    if (api is null) throw new ArgumentNullException(nameof(api));

    var request = new AuthoritiesApiRequest();

    action?.Invoke(request);

    return api.FederalAsync(request, cancellation);
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
  public static IAsyncEnumerable<IAuthority> RegionalAsync(this IAuthoritiesApi api, Action<IAuthoritiesApiRequest> action = null, CancellationToken cancellation = default)
  {
    if (api is null) throw new ArgumentNullException(nameof(api));

    var request = new AuthoritiesApiRequest();

    action?.Invoke(request);

    return api.RegionalAsync(request, cancellation);
  }
}