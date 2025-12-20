using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IDeputy"/> interface.</para>
/// </summary>
/// <seealso cref="IDeputy"/>
public static class IDeputyExtensions
{
  /// <param name="deputy">Deputy instance.</param>
  extension(IDeputy deputy)
  {
    /// <summary>
    ///   <para>Returns work position of deputy as instance of <see cref="DeputyPosition"/> enumeration.</para>
    /// </summary>
    /// <returns>Work position of deputy, or a <c>null</c> reference if <see cref="Position"/> property was not yet set.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="deputy"/> is <see langword="null"/>.</exception>
    public DeputyPosition? Position()
    {
      if (deputy is null) throw new ArgumentNullException(nameof(deputy));

      return deputy.Position switch
      {
        "Депутат ГД" => DeputyPosition.DumaDeputy,
        "Член СФ" => DeputyPosition.FederationCouncilMember,
        _ => null
      };
    }
  }

  /// <param name="deputies">Source sequence of deputies to filter.</param>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  extension<TEntity>(IEnumerable<TEntity> deputies) where TEntity : IDeputy
  {
    /// <summary>
    ///   <para>Filters sequence of deputies, leaving those with specified position.</para>
    /// </summary>
    /// <param name="position">Position to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of deputies with specified position.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="deputies"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Position(string position) => deputies?.Where(deputy => deputy is not null && deputy.Position.ToInvariantString().Contains(position.ToInvariantString())) ?? throw new ArgumentNullException(nameof(deputies));
  }
}