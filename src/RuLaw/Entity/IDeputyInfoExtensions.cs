using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IDeputyInfo"/>.</para>
/// </summary>
/// <seealso cref="IDeputyInfo"/>
public static class IDeputyInfoExtensions
{
  /// <summary>
  ///   <para>Filters sequence of deputies, leaving those containing a given part in their names.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="deputies">Source sequence of deputies to filter.</param>
  /// <param name="name">Part or full name to search for (case-insensitive).</param>
  /// <returns>Filtered sequence of deputies with specified name.</returns>
  public static IEnumerable<TEntity> FullName<TEntity>(this IEnumerable<TEntity> deputies, string name) where TEntity : IDeputyInfo
  {
    if (deputies is null) throw new ArgumentNullException(nameof(deputies));
    if (name is null) throw new ArgumentNullException(nameof(name));
    if (name.IsEmpty()) throw new ArgumentException(nameof(name));

    return deputies.Where(deputy => deputy != null && deputy.FullName.ToLowerInvariant().Contains(name.ToLowerInvariant()));
  }

  /// <summary>
  ///   <para>Filters sequence of deputies, leaving those that were born in specified date period.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="deputies">Source sequence of deputies to filter.</param>
  /// <param name="from">Start date of period.</param>
  /// <param name="to">End date of period.</param>
  /// <returns>Filtered sequence of deputies that were born between <paramref name="from"/> and <paramref name="to"/> dates.</returns>
  public static IEnumerable<TEntity> BirthDate<TEntity>(this IEnumerable<TEntity> deputies, DateTimeOffset? from = null, DateTimeOffset? to = null) where TEntity : IDeputyInfo
  {
    if (deputies is null) throw new ArgumentNullException(nameof(deputies));

    if (from != null)
    {
      deputies = deputies.Where(deputy => deputy != null && deputy.BirthDate >= from.Value);
    }

    if (to != null)
    {
      deputies = deputies.Where(deputy => deputy != null && deputy.BirthDate <= to.Value);
    }

    return deputies;
  }

  /// <summary>
  ///   <para>Filters sequence of deputies, leaving those with a work timespan in specified borders.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="deputies">Source sequence of deputies to filter.</param>
  /// <param name="from">Lower bound of work starting date.</param>
  /// <param name="to">Upper bound of work ending date.</param>
  /// <returns>Filtered sequence of deputies.</returns>
  public static IEnumerable<TEntity> WorkDate<TEntity>(this IEnumerable<TEntity> deputies, DateTimeOffset? from = null, DateTimeOffset? to = null) where TEntity : IDeputyInfo
  {
    if (deputies is null) throw new ArgumentNullException(nameof(deputies));

    if (from != null)
    {
      deputies = deputies.Where(deputy => deputy != null && deputy.WorkStartDate >= from.Value);
    }

    if (to != null)
    {
      deputies = deputies.Where(deputy => deputy != null && ((deputy.WorkEndDate.HasValue && deputy.WorkEndDate <= to.Value) || deputy.WorkEndDate == null));
    }

    return deputies;
  }

  /// <summary>
  ///   <para>Filters sequence of deputies, leaving those belonging to specified faction.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="deputies">Source sequence of deputies to filter.</param>
  /// <param name="faction">Faction name to search for (case-insensitive).</param>
  /// <returns>Filtered sequence of deputies that belong to specified faction.</returns>
  public static IEnumerable<TEntity> Faction<TEntity>(this IEnumerable<TEntity> deputies, string faction) where TEntity : IDeputyInfo
  {
    if (deputies is null) throw new ArgumentNullException(nameof(deputies));
    if (faction is null) throw new ArgumentNullException(nameof(faction));
    if (faction.IsEmpty()) throw  new ArgumentException(nameof(faction));

    return deputies.Where(deputy => deputy != null && string.Equals(deputy.FactionName, faction, StringComparison.InvariantCultureIgnoreCase));
  }

  /// <summary>
  ///   <para>Filters sequence of deputies, leaving those that have a specified scientific degree.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="deputies">Source sequence of deputies to filter.</param>
  /// <param name="degree">Scientific degree to search for (case-insensitive).</param>
  /// <returns>Filtered sequence of deputies that have a specified degree.</returns>
  public static IEnumerable<TEntity> Degree<TEntity>(this IEnumerable<TEntity> deputies, string degree) where TEntity : IDeputyInfo
  {
    if (deputies is null) throw new ArgumentNullException(nameof(deputies));
    if (degree is null) throw new ArgumentNullException(nameof(degree));
    if (degree.IsEmpty()) throw new ArgumentException(nameof(degree));

    return deputies.Where(deputy => deputy != null && deputy.Degrees.Any(x => string.Equals(x, degree, StringComparison.InvariantCultureIgnoreCase)));
  }

  /// <summary>
  ///   <para>Filters sequence of deputies, leaving those having a specified rank.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="deputies">Source sequence of deputies to filter.</param>
  /// <param name="rank">Rank to search for (case-insensitive).</param>
  /// <returns>Filtered sequence of deputies that have a specified rank.</returns>
  public static IEnumerable<TEntity> Rank<TEntity>(this IEnumerable<TEntity> deputies, string rank) where TEntity : IDeputyInfo
  {
    if (deputies is null) throw new ArgumentNullException(nameof(deputies));
    if (rank is null) throw new ArgumentNullException(nameof(rank));
    if (rank.IsEmpty()) throw new ArgumentException(nameof(rank));

    return deputies.Where(deputy => deputy != null && deputy.Ranks.Any(x => string.Equals(x, rank, StringComparison.InvariantCultureIgnoreCase)));
  }

  /// <summary>
  ///   <para>Filters sequence of deputies, leaving those linked to a specified region.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="deputies">Source sequence of deputies to filter.</param>
  /// <param name="region">Region to search for (case-insensitive).</param>
  /// <returns>Filtered sequence of deputies linked to a specified region.</returns>
  public static IEnumerable<TEntity> Region<TEntity>(this IEnumerable<TEntity> deputies, string region) where TEntity : IDeputyInfo
  {
    if (deputies is null) throw new ArgumentNullException(nameof(deputies));
    if (region is null) throw new ArgumentNullException(nameof(region));
    if (region.IsEmpty()) throw new ArgumentException(nameof(region));

    return deputies.Where(deputy => deputy != null && deputy.Regions.Any(x => string.Equals(x, region, StringComparison.InvariantCultureIgnoreCase)));
  }
}