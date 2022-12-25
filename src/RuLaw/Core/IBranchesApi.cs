namespace RuLaw;

/// <summary>
///   <para></para>
/// </summary>
public interface IBranchesApi
{
  /// <summary>
  ///   <para>Returns list of laws branches.</para>
  /// </summary>
  /// <param name="cancellation"></param>
  /// <returns>Collection of laws branches.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-otrasley-zakonodatelstva"/>
  IAsyncEnumerable<ILawBranch> All(CancellationToken cancellation = default);
}