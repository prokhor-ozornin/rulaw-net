namespace RuLaw;

/// <summary>
///   <para></para>
/// </summary>
public interface IStagesApi
{
  /// <summary>
  ///   <para>Returns list of laws review stages.</para>
  /// </summary>
  /// <param name="cancellation"></param>
  /// <returns>Collection of stages.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-stadiy-rassmotreniya"/>
  IAsyncEnumerable<IPhaseStage> All(CancellationToken cancellation = default);
}