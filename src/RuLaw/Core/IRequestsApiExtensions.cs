using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IRequestsApi"/>.</para>
/// </summary>
/// <seealso cref="IRequestsApi"/>
public static class IRequestsApiExtensions
{
  /// <summary>
  ///   <para>Returns list of deputies requests.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="requests">Collection of requests.</param>
  /// <param name="cancellation"></param>
  /// <returns><c>true</c> if call was successful and <paramref name="requests"/> output parameter contains list of deputies requests, or <c>false</c> if call failed and <paramref name="requests"/> output parameter is a <c>null</c> reference.</returns>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/deputatskie-zaprosi"/>
  public static bool All(this IRequestsApi api, out IEnumerable<IDeputyRequest>? requests, CancellationToken cancellation = default)
  {
    try
    {
      requests = api.All(cancellation).ToList(cancellation).Result;
      return true;
    }
    catch
    {
      requests = null;
      return false;
    }
  }
}