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
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-sozivov-i-sessiy"/>
  public static IEnumerable<IConvocation> All(this IConvocationsApi api) => api is not null ? api.AllAsync().ToListAsync().Result : throw new ArgumentNullException(nameof(api));
}