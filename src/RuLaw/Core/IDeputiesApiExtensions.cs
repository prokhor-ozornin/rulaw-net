using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IDeputiesApi"/> interface.</para>
/// </summary>
/// <seealso cref="IDeputiesApi"/>
public static class IDeputiesApiExtensions
{
  /// <param name="api">API caller instance to be used.</param>
  extension(IDeputiesApi api)
  {
    /// <summary>
    ///   <para>Returns detailed information about specific deputy of the State Duma.</para>
    /// </summary>
    /// <param name="id">Identifier of deputy.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/svedeniya-o-deputate"/>
    public IDeputyInfo Find(long id) => api?.FindAsync(id).Result ?? throw new ArgumentNullException(nameof(api));

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    public IEnumerable<IDeputy> Search(IDeputiesApiRequest request = null) => api?.SearchAsync(request).ToListAsync().Result ?? throw new ArgumentNullException(nameof(api));

    /// <summary>
    ///   <para>Returns list of deputies of the State Duma and members of the Federation Council.</para>
    /// </summary>
    /// <param name="action">Delegate to configure additional parameters of request.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-deputatov-gd-i-chlenov-sf"/>
    public IEnumerable<IDeputy> Search(Action<IDeputiesApiRequest> action = null) => api?.SearchAsync(action).ToListAsync().Result ?? throw new ArgumentNullException(nameof(api));

    /// <summary>
    ///   <para>Returns list of deputies of the State Duma and members of the Federation Council.</para>
    /// </summary>
    /// <param name="action">Delegate to configure additional parameters of request.</param>
    /// <param name="cancellation"></param>
    /// <returns>Collection of deputies.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-deputatov-gd-i-chlenov-sf"/>
    public IAsyncEnumerable<IDeputy> SearchAsync(Action<IDeputiesApiRequest> action = null, CancellationToken cancellation = default)
    {
      if (api is null) throw new ArgumentNullException(nameof(api));

      var request = new DeputiesApiRequest();

      action?.Invoke(request);

      return api.SearchAsync(request, cancellation);
    }
  }
}