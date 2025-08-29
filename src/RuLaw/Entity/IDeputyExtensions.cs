using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IDeputy"/> interface.</para>
/// </summary>
/// <seealso cref="IDeputy"/>
public static class IDeputyExtensions
{
  /// <summary>
  ///   <para>Returns work position of deputy as instance of <see cref="DeputyPosition"/> enumeration.</para>
  /// </summary>
  /// <param name="deputy">Deputy instance.</param>
  /// <returns>Work position of deputy, or a <c>null</c> reference if <see cref="Position"/> property was not yet set.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="deputy"/> is <see langword="null"/>.</exception>
  public static DeputyPosition? Position(this IDeputy deputy)
  {
    if (deputy is null) throw new ArgumentNullException(nameof(deputy));

    return deputy.Position switch
    {
      "Депутат ГД" => DeputyPosition.DumaDeputy,
      "Член СФ" => DeputyPosition.FederationCouncilMember,
      _ => null
    };
  }

  /// <summary>
  ///   <para>Filters sequence of deputies, leaving those with specified position.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="deputies">Source sequence of deputies to filter.</param>
  /// <param name="position">Position to search for (case-insensitive).</param>
  /// <returns>Filtered sequence of deputies with specified position.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="deputies"/> is <see langword="null"/>.</exception>
  public static IEnumerable<TEntity> Position<TEntity>(this IEnumerable<TEntity> deputies, string position) where TEntity : IDeputy => deputies?.Where(deputy => deputy is not null && deputy.Position.ToInvariantString().Contains(position.ToInvariantString())) ?? throw new ArgumentNullException(nameof(deputies));
}