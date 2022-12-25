namespace RuLaw;

/// <summary>
///   <para></para>
/// </summary>
public interface ICommitteesApi
{
  /// <summary>
  ///   <para>Returns list of committees.</para>
  /// </summary>
  /// <param name="cancellation"></param>
  /// <returns>Collection of committees.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-komitetov"/>
  IAsyncEnumerable<ICommittee> All(CancellationToken cancellation = default);
}