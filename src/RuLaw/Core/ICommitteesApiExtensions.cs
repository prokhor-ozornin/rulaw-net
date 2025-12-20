using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="ICommitteesApi"/> interface.</para>
/// </summary>
/// <seealso cref="ICommitteesApi"/>
public static class ICommitteesApiExtensions
{
  /// <param name="api">API caller instance to be used.</param>
  extension(ICommitteesApi api)
  {
    /// <summary>
    ///   <para>Returns list of committees.</para>
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-komitetov"/>
    public IEnumerable<ICommittee> All() => api?.AllAsync().ToListAsync().Result ?? throw new ArgumentNullException(nameof(api));
  }
}