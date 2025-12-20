namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IPeriodable"/> interface.</para>
/// </summary>
/// <seealso cref="IPeriodable"/>
public static class IPeriodableExtensions
{
  /// <param name="entities">Source sequence of entities.</param>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  extension<TEntity>(IEnumerable<TEntity> entities) where TEntity : IPeriodable
  {
    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with a date/time period located between specified borders.</para>
    /// </summary>
    /// <param name="from">Lower bound of starting period.</param>
    /// <param name="to">Upper bound of ending period.</param>
    /// <returns>Filters sequence of entities.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Period(DateTimeOffset? from = null, DateTimeOffset? to = null)
    {
      if (entities is null) throw new ArgumentNullException(nameof(entities));

      if (from is not null)
      {
        entities = entities.Where(entity => entity is not null && entity.FromDate >= from);
      }

      if (to is not null)
      {
        entities = entities.Where(entity => entity is not null && (entity.ToDate is null || entity.ToDate <= to));
      }

      return entities;
    }
  }
}