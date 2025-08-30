using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="ICommitteesApi"/> interface.</para>
/// </summary>
/// <seealso cref="ICommitteesApi"/>
public static class ICommitteesApiExtensions
{
  /// <summary>
  ///   <para>Returns list of committees.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-komitetov"/>
  public static IEnumerable<ICommittee> All(this ICommitteesApi api) => api?.AllAsync().ToListAsync().Result ?? throw new ArgumentNullException(nameof(api));
}