﻿namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IPeriodable"/>.</para>
/// </summary>
/// <seealso cref="IPeriodable"/>
public static class IPeriodableExtensions
{
  /// <summary>
  ///   <para>Filters sequence of entities, leaving those with a date/time period located between specified borders.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="entities">Source sequence of entities.</param>
  /// <param name="from">Lower bound of starting period.</param>
  /// <param name="to">Upper bound of ending period.</param>
  /// <returns>Filters sequence of entities.</returns>
  public static IEnumerable<TEntity> Period<TEntity>(this IEnumerable<TEntity> entities, DateTimeOffset? from = null, DateTimeOffset? to = null) where TEntity : IPeriodable
  {
    if (from != null)
    {
      entities = entities.Where(entity => entity != null && entity.FromDate >= from);
    }

    if (to != null)
    {
      entities = entities.Where(entity => entity != null && ((entity.ToDate != null && entity.ToDate <= to) || entity.ToDate == null));
    }

    return entities;
  }
}