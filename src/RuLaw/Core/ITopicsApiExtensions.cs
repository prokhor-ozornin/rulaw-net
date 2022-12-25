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
  /// <param name="topics">Collection of topics.</param>
  /// <param name="cancellation"></param>
  /// <returns><c>true</c> if call was successful and <paramref name="topics"/> output parameter contains list of topics, or <c>false</c> if call failed and <paramref name="topics"/> output parameter is a <c>null</c> reference.</returns>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-tematicheskih-blokov"/>
  public static bool All(this ITopicsApi api, out IEnumerable<ITopic>? topics, CancellationToken cancellation = default)
  {
    try
    {
      topics = api.All(cancellation).ToList(cancellation).Result;
      return true;
    }
    catch
    {
      topics = null;
      return false;
    }
  }
}