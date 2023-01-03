namespace RuLaw;

/// <summary>
///   <para></para>
/// </summary>
public interface IConvocationsApi
{
  /// <summary>
  ///   <para>Returns list of State Duma's convocations and sessions.</para>
  /// </summary>
  /// <param name="cancellation"></param>
  /// <returns>Collection of convocations.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-sozivov-i-sessiy"/>
  IAsyncEnumerable<IConvocation> AllAsync(CancellationToken cancellation = default);
}