using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IBranchesApi"/> interface.</para>
/// </summary>
/// <seealso cref="IBranchesApi"/>
public static class IBranchesApiExtensions
{
  /// <summary>
  ///   <para>Returns list of laws branches.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
  /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-otrasley-zakonodatelstva"/>
  public static IEnumerable<ILawBranch> All(this IBranchesApi api) => api?.AllAsync().ToListAsync().Result ?? throw new ArgumentNullException(nameof(api));
}