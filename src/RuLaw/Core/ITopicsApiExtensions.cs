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
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-tematicheskih-blokov"/>
  public static IEnumerable<ITopic> All(this ITopicsApi api) => api is not null ? api.AllAsync().ToListAsync().Result : throw new ArgumentNullException(nameof(api));
}