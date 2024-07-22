using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IStagesApi"/> interface.</para>
/// </summary>
/// <seealso cref="IStagesApi"/>
public static class IStagesApiExtensions
{
  /// <summary>
  ///   <para>Returns list of laws review stages.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-stadiy-rassmotreniya"/>
  public static IEnumerable<IPhaseStage> All(this IStagesApi api) => api is not null ? api.AllAsync().ToListAsync().Result : throw new ArgumentNullException(nameof(api));
}