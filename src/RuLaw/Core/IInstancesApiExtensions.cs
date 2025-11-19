using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IInstancesApi"/> interface.</para>
/// </summary>
/// <seealso cref="IInstancesApi"/>
public static class IInstancesApiExtensions
{
  /// <param name="api"></param>
  extension(IInstancesApi api)
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    public IEnumerable<IInstance> Search(IInstancesApiRequest request = null) => api?.SearchAsync(request).ToListAsync().Result ?? throw new ArgumentNullException(nameof(api));

    /// <summary>
    ///   <para>Returns list of instances.</para>
    /// </summary>
    /// <param name="action">Delegate to configure additional parameters of request.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-instantsiy-rassmotreniya"/>
    public IEnumerable<IInstance> Search(Action<IInstancesApiRequest> action = null) => api?.SearchAsync(action).ToListAsync().Result ?? throw new ArgumentNullException(nameof(api));

    /// <summary>
    ///   <para>Returns list of instances.</para>
    /// </summary>
    /// <param name="action">Delegate to configure additional parameters of request.</param>
    /// <param name="cancellation"></param>
    /// <returns>Collection of instances.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-instantsiy-rassmotreniya"/>
    public IAsyncEnumerable<IInstance> SearchAsync(Action<IInstancesApiRequest> action = null, CancellationToken cancellation = default)
    {
      if (api is null) throw new ArgumentNullException(nameof(api));

      var request = new InstancesApiRequest();

      action?.Invoke(request);

      return api.SearchAsync(request, cancellation);
    }
  }
}