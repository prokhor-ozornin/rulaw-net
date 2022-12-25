using Catharsis.Commons;

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
  /// <param name="deputy">Detailed deputy information.</param>
  /// <param name="id">Identifier of deputy.</param>
  /// <param name="cancellation"></param>
  /// <returns><c>true</c> if call was successful and <paramref name="deputy"/> output parameter contains deputy information, or <c>false</c> if call failed and <paramref name="deputy"/> output parameter is a <c>null</c> reference.</returns>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/svedeniya-o-deputate"/>
  public static bool Find(this IDeputiesApi api, out IDeputyInfo? deputy, long id, CancellationToken cancellation = default)
  {
    try
    {
      deputy = api.Find(id, cancellation).Result;
      return true;
    }
    catch
    {
      deputy = null;
      return false;
    }
  }

  /// <summary>
  ///   <para>Returns list of deputies of the State Duma and members of the Federation Council.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Collection of deputies.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-deputatov-gd-i-chlenov-sf"/>
  public static IAsyncEnumerable<IDeputy> Search(this IDeputiesApi api, Action<IDeputiesApiRequest>? action = null, CancellationToken cancellation = default)
  {
    var request = new DeputiesApiRequest();

    action?.Invoke(request);

    return api.Search(request, cancellation);
  }

  /// <summary>
  ///   <para>Returns list of deputies of the State Duma and members of the Federation Council.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="deputies">Collection of deputies.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns><c>true</c> if call was successful and <paramref name="deputies"/> output parameter contains list of deputies, or <c>false</c> if call failed and <paramref name="deputies"/> output parameter is a <c>null</c> reference.</returns>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-deputatov-gd-i-chlenov-sf"/>
  public static bool Search(this IDeputiesApi api, out IEnumerable<IDeputy>? deputies, Action<IDeputiesApiRequest>? action = null, CancellationToken cancellation = default)
  {
    try
    {
      deputies = Search(api, action, cancellation).ToList(cancellation).Result;
      return true;
    }
    catch
    {
      deputies = null;
      return false;
    }
  }
}