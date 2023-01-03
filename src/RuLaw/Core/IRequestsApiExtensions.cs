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
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/deputatskie-zaprosi"/>
  public static IEnumerable<IDeputyRequest> All(this IRequestsApi api) => api.AllAsync().ToListAsync().Result;
}