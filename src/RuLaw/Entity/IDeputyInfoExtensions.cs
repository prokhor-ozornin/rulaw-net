using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IDeputyInfo"/> interface.</para>
/// </summary>
/// <seealso cref="IDeputyInfo"/>
public static class IDeputyInfoExtensions
{
  /// <param name="deputies">Source sequence of deputies to filter.</param>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  extension<TEntity>(IEnumerable<TEntity> deputies) where TEntity : IDeputyInfo
  {
    /// <summary>
    ///   <para>Filters sequence of deputies, leaving those containing a given part in their names.</para>
    /// </summary>
    /// <param name="name">Part or full name to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of deputies with specified name.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="deputies"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> FullName(string name) => deputies?.Where(deputy => deputy is not null && deputy.FullName.ToInvariantString().Contains(name.ToInvariantString())) ?? throw new ArgumentNullException(nameof(deputies));

    /// <summary>
    ///   <para>Filters sequence of deputies, leaving those that were born in specified date period.</para>
    /// </summary>
    /// <param name="from">Start date of period.</param>
    /// <param name="to">End date of period.</param>
    /// <returns>Filtered sequence of deputies that were born between <paramref name="from"/> and <paramref name="to"/> dates.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="deputies"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> BirthDate(DateTimeOffset? from = null, DateTimeOffset? to = null)
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
    /// <param name="from">Lower bound of work starting date.</param>
    /// <param name="to">Upper bound of work ending date.</param>
    /// <returns>Filtered sequence of deputies.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="deputies"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> WorkDate(DateTimeOffset? from = null, DateTimeOffset? to = null)
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
    /// <param name="faction">Faction name to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of deputies that belong to specified faction.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="deputies"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Faction(string faction) => deputies?.Where(deputy => deputy is not null && deputy.FactionName.ToInvariantString().Equals(faction.ToInvariantString())) ?? throw new ArgumentNullException(nameof(deputies));

    /// <summary>
    ///   <para>Filters sequence of deputies, leaving those that have a specified scientific degree.</para>
    /// </summary>
    /// <param name="degree">Scientific degree to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of deputies that have a specified degree.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="deputies"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Degree(string degree) => deputies?.Where(deputy => deputy is not null && deputy.Degrees.Any(x => x.ToInvariantString().Equals(degree.ToInvariantString()))) ?? throw new ArgumentNullException(nameof(deputies));

    /// <summary>
    ///   <para>Filters sequence of deputies, leaving those having a specified rank.</para>
    /// </summary>
    /// <param name="rank">Rank to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of deputies that have a specified rank.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="deputies"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Rank(string rank) => deputies?.Where(deputy => deputy is not null && deputy.Ranks.Any(x => x.ToInvariantString().Equals(rank.ToInvariantString()))) ?? throw new ArgumentNullException(nameof(deputies));

    /// <summary>
    ///   <para>Filters sequence of deputies, leaving those linked to a specified region.</para>
    /// </summary>
    /// <param name="region">Region to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of deputies linked to a specified region.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="deputies"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Region(string region) => deputies?.Where(deputy => deputy is not null && deputy.Regions.Any(x => x.ToInvariantString().Equals(region.ToInvariantString()))) ?? throw new ArgumentNullException(nameof(deputies));
  }
}