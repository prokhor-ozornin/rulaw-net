using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IDeputy"/>.</para>
/// </summary>
/// <seealso cref="IDeputy"/>
public static class IDeputyExtensions
{
  /// <summary>
  ///   <para>Returns work position of deputy as instance of <see cref="DeputyPosition"/> enumeration.</para>
  /// </summary>
  /// <param name="deputy">Deputy instance.</param>
  /// <returns>Work position of deputy, or a <c>null</c> reference if <see cref="Position"/> property was not yet set.</returns>
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
  public static IEnumerable<TEntity> Position<TEntity>(this IEnumerable<TEntity> deputies, string position) where TEntity : IDeputy
  {
    if (deputies is null) throw new ArgumentNullException(nameof(deputies));

    return deputies.Where(deputy => deputy is not null && (deputy.Position ?? string.Empty).ToLowerInvariant().Contains((position ?? string.Empty).ToLowerInvariant()));
  }
}