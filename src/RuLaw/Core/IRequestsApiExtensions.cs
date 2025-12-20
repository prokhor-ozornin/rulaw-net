using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IRequestsApi"/> interface.</para>
/// </summary>
/// <seealso cref="IRequestsApi"/>
public static class IRequestsApiExtensions
{
  /// <param name="api">API caller instance to be used.</param>
  extension(IRequestsApi api)
  {
    /// <summary>
    ///   <para>Returns list of deputies requests.</para>
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/deputatskie-zaprosi"/>
    public IEnumerable<IDeputyRequest> All() => api?.AllAsync().ToListAsync().Result ?? throw new ArgumentNullException(nameof(api));
  }
}