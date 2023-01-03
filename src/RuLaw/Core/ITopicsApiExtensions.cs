using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="ITopicsApi"/>.</para>
/// </summary>
/// <seealso cref="ITopicsApi"/>
public static class ITopicsApiExtensions
{
  /// <summary>
  ///   <para>Returns list of topics (subject units).</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-tematicheskih-blokov"/>
  public static IEnumerable<ITopic> All(this ITopicsApi api) => api.AllAsync().ToListAsync().Result;
}