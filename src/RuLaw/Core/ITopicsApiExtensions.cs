using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="ITopicsApi"/> interface.</para>
/// </summary>
/// <seealso cref="ITopicsApi"/>
public static class ITopicsApiExtensions
{
  /// <param name="api">API caller instance to be used.</param>
  extension(ITopicsApi api)
  {
    /// <summary>
    ///   <para>Returns list of topics (subject units).</para>
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-tematicheskih-blokov"/>
    public IEnumerable<ITopic> All() => api?.AllAsync().ToListAsync().Result ?? throw new ArgumentNullException(nameof(api));
  }
}