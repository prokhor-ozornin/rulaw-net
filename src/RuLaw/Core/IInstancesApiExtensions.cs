using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IInstancesApi"/>.</para>
/// </summary>
/// <seealso cref="IInstancesApi"/>
public static class IInstancesApiExtensions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="api"></param>
  /// <param name="request"></param>
  /// <returns></returns>
  public static IEnumerable<IInstance> Search(this IInstancesApi api, IInstancesApiRequest request = null) => api.SearchAsync(request).ToListAsync().Result;

  /// <summary>
  ///   <para>Returns list of instances.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-instantsiy-rassmotreniya"/>
  public static IEnumerable<IInstance> Search(this IInstancesApi api, Action<IInstancesApiRequest> action = null) => api.SearchAsync(action).ToListAsync().Result;

  /// <summary>
  ///   <para>Returns list of instances.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Collection of instances.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-instantsiy-rassmotreniya"/>
  public static IAsyncEnumerable<IInstance> SearchAsync(this IInstancesApi api, Action<IInstancesApiRequest> action = null, CancellationToken cancellation = default)
  {
    var request = new InstancesApiRequest();

    action?.Invoke(request);

    return api.SearchAsync(request, cancellation);
  }
}