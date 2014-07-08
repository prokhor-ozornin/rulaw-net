using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IDateable"/>.</para>
  /// </summary>
  /// <seealso cref="IDateable"/>
  public static class IDateableExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with a date and time in specified range.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="from">Lower bound of date and time range.</param>
    /// <param name="to">Upper bound of date and time range.</param>
    /// <returns>Filtered sequence of entities with creation date and time ranging inclusively from <paramref name="from"/> to <paramref name="to"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<ENTITY> Date<ENTITY>(this IEnumerable<ENTITY> entities, DateTime? from = null, DateTime? to = null) where ENTITY : IDateable
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity != null && entity.Date >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity != null && entity.Date <= to.Value);
      }

      return entities;
    }
  }
}