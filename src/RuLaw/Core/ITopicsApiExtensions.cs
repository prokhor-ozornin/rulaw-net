using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="ITopicsApi"/> interface.</para>
/// </summary>
/// <seealso cref="ITopicsApi"/>
public static class ITopicsApiExtensions
{
  /// <summary>
  ///   <para>Returns list of topics (subject units).</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-tematicheskih-blokov"/>
  public static IEnumerable<ITopic> All(this ITopicsApi api) => api?.AllAsync().ToListAsync().Result ?? throw new ArgumentNullException(nameof(api));
}