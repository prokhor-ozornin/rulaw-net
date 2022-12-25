namespace RuLaw;

/// <summary>
///   <para></para>
/// </summary>
public interface ITopicsApi
{
  /// <summary>
  ///   <para>Returns list of topics (subject units).</para>
  /// </summary>
  /// <param name="cancellation"></param>
  /// <returns>Collection of topics.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-tematicheskih-blokov"/>
  IAsyncEnumerable<ITopic> All(CancellationToken cancellation = default);
}