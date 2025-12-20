using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IStagesApi"/> interface.</para>
/// </summary>
/// <seealso cref="IStagesApi"/>
public static class IStagesApiExtensions
{
  /// <param name="api">API caller instance to be used.</param>
  extension(IStagesApi api)
  {
    /// <summary>
    ///   <para>Returns list of laws review stages.</para>
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-stadiy-rassmotreniya"/>
    public IEnumerable<IPhaseStage> All() => api?.AllAsync().ToListAsync().Result ?? throw new ArgumentNullException(nameof(api));
  }
}