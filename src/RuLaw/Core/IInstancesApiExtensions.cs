using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IInstancesApi"/>.</para>
/// </summary>
/// <seealso cref="IInstancesApi"/>
public static class IInstancesApiExtensions
{
  /// <summary>
  ///   <para>Returns list of instances.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Collection of instances.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-instantsiy-rassmotreniya"/>
  public static IAsyncEnumerable<IInstance> Search(this IInstancesApi api, Action<IInstancesApiRequest>? action = null, CancellationToken cancellation = default)
  {
    var request = new InstancesApiRequest();

    action?.Invoke(request);

    return api.Search(request, cancellation);
  }

  /// <summary>
  ///   <para>Returns list of instances.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="instances">Collection of instances.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns><c>true</c> if call was successful and <paramref name="instances"/> output parameter contains list of instances, or <c>false</c> if call failed and <paramref name="instances"/> output parameter is a <c>null</c> reference.</returns>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-instantsiy-rassmotreniya"/>
  public static bool Search(this IInstancesApi api, out IEnumerable<IInstance>? instances, Action<IInstancesApiRequest>? action = null, CancellationToken cancellation = default)
  {
    try
    {
      instances = api.Search(action, cancellation).ToList(cancellation).Result;
      return true;
    }
    catch
    {
      instances = null;
      return false;
    }
  }
}