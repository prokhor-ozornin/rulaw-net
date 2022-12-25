using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IStagesApi"/>.</para>
/// </summary>
/// <seealso cref="IStagesApi"/>
public static class IStagesApiExtensions
{
  /// <summary>
  ///   <para>Returns list of laws review stages.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="stages">Collection of stages.</param>
  /// <param name="cancellation"></param>
  /// <returns><c>true</c> if call was successful and <paramref name="stages"/> output parameter contains list of stages, or <c>false</c> if call failed and <paramref name="stages"/> output parameter is a <c>null</c> reference.</returns>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-stadiy-rassmotreniya"/>
  public static bool All(this IStagesApi api, out IEnumerable<IPhaseStage>? stages, CancellationToken cancellation = default)
  {
    try
    {
      stages = api.All(cancellation).ToList(cancellation).Result;
      return true;
    }
    catch
    {
      stages = null;
      return false;
    }
  }
}