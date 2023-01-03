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
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-otrasley-zakonodatelstva"/>
  public static IEnumerable<ILawBranch> All(this IBranchesApi api) => api.AllAsync().ToListAsync().Result;
}