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
  /// <returns></returns>
  /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
  /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/deputatskie-zaprosi"/>
  public static IEnumerable<IDeputyRequest> All(this IRequestsApi api) => api?.AllAsync().ToListAsync().Result ?? throw new ArgumentNullException(nameof(api));
}