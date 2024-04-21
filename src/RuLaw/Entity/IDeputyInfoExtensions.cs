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
  public static IEnumerable<TEntity> FullName<TEntity>(this IEnumerable<TEntity> deputies, string name) where TEntity : IDeputyInfo => deputies is not null ? deputies.Where(deputy => deputy is not null && deputy.FullName.ToInvariantString().Contains(name.ToInvariantString())) : throw new ArgumentNullException(nameof(deputies));

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

    if (from is not null)
    {
      deputies = deputies.Where(deputy => deputy is not null && deputy.BirthDate >= from.Value);
    }

    if (to is not null)
    {
      deputies = deputies.Where(deputy => deputy is not null && deputy.BirthDate <= to.Value);
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

    if (from is not null)
    {
      deputies = deputies.Where(deputy => deputy is not null && deputy.WorkStartDate >= from.Value);
    }

    if (to is not null)
    {
      deputies = deputies.Where(deputy => deputy is not null && (deputy.WorkEndDate is null || deputy.WorkEndDate <= to.Value));
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
  public static IEnumerable<TEntity> Faction<TEntity>(this IEnumerable<TEntity> deputies, string faction) where TEntity : IDeputyInfo => deputies is not null ? deputies.Where(deputy => deputy is not null && deputy.FactionName.ToInvariantString().Equals(faction.ToInvariantString())) : throw new ArgumentNullException(nameof(deputies));

  /// <summary>
  ///   <para>Filters sequence of deputies, leaving those that have a specified scientific degree.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="deputies">Source sequence of deputies to filter.</param>
  /// <param name="degree">Scientific degree to search for (case-insensitive).</param>
  /// <returns>Filtered sequence of deputies that have a specified degree.</returns>
  public static IEnumerable<TEntity> Degree<TEntity>(this IEnumerable<TEntity> deputies, string degree) where TEntity : IDeputyInfo => deputies is not null ? deputies.Where(deputy => deputy is not null && deputy.Degrees.Any(x => x.ToInvariantString().Equals(degree.ToInvariantString()))) : throw new ArgumentNullException(nameof(deputies));

  /// <summary>
  ///   <para>Filters sequence of deputies, leaving those having a specified rank.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="deputies">Source sequence of deputies to filter.</param>
  /// <param name="rank">Rank to search for (case-insensitive).</param>
  /// <returns>Filtered sequence of deputies that have a specified rank.</returns>
  public static IEnumerable<TEntity> Rank<TEntity>(this IEnumerable<TEntity> deputies, string rank) where TEntity : IDeputyInfo => deputies is not null ? deputies.Where(deputy => deputy is not null && deputy.Ranks.Any(x => x.ToInvariantString().Equals(rank.ToInvariantString()))) : throw new ArgumentNullException(nameof(deputies));

  /// <summary>
  ///   <para>Filters sequence of deputies, leaving those linked to a specified region.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="deputies">Source sequence of deputies to filter.</param>
  /// <param name="region">Region to search for (case-insensitive).</param>
  /// <returns>Filtered sequence of deputies linked to a specified region.</returns>
  public static IEnumerable<TEntity> Region<TEntity>(this IEnumerable<TEntity> deputies, string region) where TEntity : IDeputyInfo => deputies is not null ? deputies.Where(deputy => deputy is not null && deputy.Regions.Any(x => x.ToInvariantString().Equals(region.ToInvariantString()))) : throw new ArgumentNullException(nameof(deputies));
}