using Catharsis.Commons;
using static System.Net.WebRequestMethods;

namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IDeputiesApi"/>.</para>
/// </summary>
/// <seealso cref="IDeputiesApi"/>
public static class IDeputiesApiExtensions
{
  /// <summary>
  ///   <para>Returns detailed information about specific deputy of the State Duma.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="id">Identifier of deputy.</param>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/svedeniya-o-deputate"/>
  public static IDeputyInfo Find(this IDeputiesApi api, long id) => api.FindAsync(id).Result;

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="api"></param>
  /// <param name="request"></param>
  /// <returns></returns>
  public static IEnumerable<IDeputy> Search(this IDeputiesApi api, IDeputiesApiRequest request = null) => api.SearchAsync(request).ToListAsync().Result;

  /// <summary>
  ///   <para>Returns list of deputies of the State Duma and members of the Federation Council.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-deputatov-gd-i-chlenov-sf"/>
  public static IEnumerable<IDeputy> Search(this IDeputiesApi api, Action<IDeputiesApiRequest> action = null) => api.SearchAsync(action).ToListAsync().Result;

  /// <summary>
  ///   <para>Returns list of deputies of the State Duma and members of the Federation Council.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Collection of deputies.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-deputatov-gd-i-chlenov-sf"/>
  public static IAsyncEnumerable<IDeputy> SearchAsync(this IDeputiesApi api, Action<IDeputiesApiRequest> action = null, CancellationToken cancellation = default)
  {
    var request = new DeputiesApiRequest();

    action?.Invoke(request);

    return api.SearchAsync(request, cancellation);
  }
}