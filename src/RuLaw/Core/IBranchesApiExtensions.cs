using Catharsis.Commons;

namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IBranchesApi"/>.</para>
/// </summary>
/// <seealso cref="IBranchesApi"/>
public static class IBranchesApiExtensions
{
  /// <summary>
  ///   <para>Returns list of laws branches.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="branches">Collection of laws branches.</param>
  /// <param name="cancellation"></param>
  /// <returns><c>true</c> if call was successful and <paramref name="branches"/> output parameter contains list of law branches, or <c>false</c> if call failed and <paramref name="branches"/> output parameter is a <c>null</c> reference.</returns>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-otrasley-zakonodatelstva"/>
  public static bool All(this IBranchesApi api, out IEnumerable<ILawBranch>? branches, CancellationToken cancellation = default)
  {
    try
    {
      branches = api.All(cancellation).ToList(cancellation).Result;
      return true;
    }
    catch
    {
      branches = null;
      return false;
    }
  }
}