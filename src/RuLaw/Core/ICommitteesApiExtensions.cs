using Catharsis.Extensions;

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
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-komitetov"/>
  public static IEnumerable<ICommittee> All(this ICommitteesApi api) => api is not null ? api.AllAsync().ToListAsync().Result : throw new ArgumentNullException(nameof(api));
}