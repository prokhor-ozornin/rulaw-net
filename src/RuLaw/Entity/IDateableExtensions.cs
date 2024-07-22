namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IDateable"/> interface.</para>
/// </summary>
/// <seealso cref="IDateable"/>
public static class IDateableExtensions
{
  /// <summary>
  ///   <para>Filters sequence of entities, leaving those with a date and time in specified range.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="entities">Source sequence of entities to filter.</param>
  /// <param name="from">Lower bound of date and time range.</param>
  /// <param name="to">Upper bound of date and time range.</param>
  /// <returns>Filtered sequence of entities with creation date and time ranging inclusively from <paramref name="from"/> to <paramref name="to"/>.</returns>
  public static IEnumerable<TEntity> Date<TEntity>(this IEnumerable<TEntity> entities, DateTimeOffset? from = null, DateTimeOffset? to = null) where TEntity : IDateable
  {
    if (entities is null) throw new ArgumentNullException(nameof(entities));

    if (from is not null)
    {
      entities = entities.Where(entity => entity is not null && entity.Date >= from.Value);
    }

    if (to is not null)
    {
      entities = entities.Where(entity => entity is not null && entity.Date <= to.Value);
    }

    return entities;
  }
}