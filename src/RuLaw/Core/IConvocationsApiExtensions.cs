using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IConvocationsApi"/> interface.</para>
/// </summary>
/// <seealso cref="IConvocationsApi"/>
public static class IConvocationsApiExtensions
{
  /// <summary>
  ///   <para>Returns list of State Duma's convocations and sessions.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
  /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-sozivov-i-sessiy"/>
  public static IEnumerable<IConvocation> All(this IConvocationsApi api) => api?.AllAsync().ToListAsync().Result ?? throw new ArgumentNullException(nameof(api));
}