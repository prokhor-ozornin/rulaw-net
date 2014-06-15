using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IPeriodable"/>.</para>
  /// </summary>
  /// <seealso cref="IPeriodable"/>
  public static class IPeriodableExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with a date/time period located between specified borders.</para>
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities.</param>
    /// <param name="from">Lower bound of starting period.</param>
    /// <param name="to">Upper bound of ending period.</param>
    /// <returns>Filters sequence of entities.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<T> Period<T>(this IEnumerable<T> entities, DateTime? from = null, DateTime? to = null) where T : IPeriodable
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity != null && entity.FromDate >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity != null && ((entity.ToDate.HasValue && entity.ToDate <= to.Value) || entity.ToDate == null));
      }

      return entities;
    }
  }
}