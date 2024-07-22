using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IRequestsApi"/> interface.</para>
/// </summary>
/// <seealso cref="IRequestsApi"/>
public static class IRequestsApiExtensions
{
  /// <summary>
  ///   <para>Returns list of deputies requests.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/deputatskie-zaprosi"/>
  public static IEnumerable<IDeputyRequest> All(this IRequestsApi api) => api is not null ? api.AllAsync().ToListAsync().Result : throw new ArgumentNullException(nameof(api));
}