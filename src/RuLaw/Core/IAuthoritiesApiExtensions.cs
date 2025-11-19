using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IAuthoritiesApi"/> interface.</para>
/// </summary>
/// <seealso cref="IAuthoritiesApi"/>
public static class IAuthoritiesApiExtensions
{
  /// <param name="api"></param>
  extension(IAuthoritiesApi api)
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    public IEnumerable<IAuthority> Federal(IAuthoritiesApiRequest request = null) => api?.FederalAsync(request).ToListAsync().Result ?? throw new ArgumentNullException(nameof(api));

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    public IEnumerable<IAuthority> Federal(Action<IAuthoritiesApiRequest> action = null) => api?.FederalAsync(action).ToListAsync().Result ?? throw new ArgumentNullException(nameof(api));

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    public IEnumerable<IAuthority> Regional(IAuthoritiesApiRequest request = null) => api?.RegionalAsync(request).ToListAsync().Result ?? throw new ArgumentNullException(nameof(api));

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    public IEnumerable<IAuthority> Regional(Action<IAuthoritiesApiRequest> action = null) => api?.RegionalAsync(action).ToListAsync().Result ?? throw new ArgumentNullException(nameof(api));

    /// <summary>
    ///   <para>Returns list of federal law authorities.</para>
    /// </summary>
    /// <param name="action">Delegate to configure additional parameters of request.</param>
    /// <param name="cancellation"></param>
    /// <returns>Collection of authorities.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-federalnih-organov-vlasti"/>
    public IAsyncEnumerable<IAuthority> FederalAsync(Action<IAuthoritiesApiRequest> action = null, CancellationToken cancellation = default)
    {
      if (api is null) throw new ArgumentNullException(nameof(api));

      var request = new AuthoritiesApiRequest();

      action?.Invoke(request);

      return api.FederalAsync(request, cancellation);
    }

    /// <summary>
    ///   <para>Returns list of regional law authorities.</para>
    /// </summary>
    /// <param name="action">Delegate to configure additional parameters of request.</param>
    /// <param name="cancellation"></param>
    /// <returns>Collection of authorities.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-regionalnih-organov-vlasti"/>
    public IAsyncEnumerable<IAuthority> RegionalAsync(Action<IAuthoritiesApiRequest> action = null, CancellationToken cancellation = default)
    {
      if (api is null) throw new ArgumentNullException(nameof(api));

      var request = new AuthoritiesApiRequest();

      action?.Invoke(request);

      return api.RegionalAsync(request, cancellation);
    }
  }
}