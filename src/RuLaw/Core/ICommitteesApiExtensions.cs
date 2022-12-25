using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="ICommitteesApi"/>.</para>
/// </summary>
/// <seealso cref="ICommitteesApi"/>
public static class ICommitteesApiExtensions
{
  /// <summary>
  ///   <para>Returns list of committees.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="committees">Collection of committees.</param>
  /// <param name="cancellation"></param>
  /// <returns><c>true</c> if call was successful and <paramref name="committees"/> output parameter contains list of committees, or <c>false</c> if call failed and <paramref name="committees"/> output parameter is a <c>null</c> reference.</returns>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-komitetov"/>
  public static bool All(this ICommitteesApi api, out IEnumerable<ICommittee>? committees, CancellationToken cancellation = default)
  {
    try
    {
      committees = api.All(cancellation).ToList(cancellation).Result;
      return true;
    }
    catch
    {
      committees = null;
      return false;
    }
  }
}