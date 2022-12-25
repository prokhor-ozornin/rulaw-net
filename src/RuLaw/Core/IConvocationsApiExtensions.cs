using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IConvocationsApi"/>.</para>
/// </summary>
/// <seealso cref="IConvocationsApi"/>
public static class IConvocationsApiExtensions
{
  /// <summary>
  ///   <para>Returns list of State Duma's convocations and sessions.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="convocations">Collection of convocations.</param>
  /// <param name="cancellation"></param>
  /// <returns><c>true</c> if call was successful and <paramref name="convocations"/> output parameter contains list of convocations, or <c>false</c> if call failed and <paramref name="convocations"/> output parameter is a <c>null</c> reference.</returns>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-sozivov-i-sessiy"/>
  public static bool All(this IConvocationsApi api, out IEnumerable<IConvocation>? convocations, CancellationToken cancellation = default)
  {
    try
    {
      convocations = api.All(cancellation).ToList(cancellation).Result;
      return true;
    }
    catch
    {
      convocations = null;
      return false;
    }
  }
}