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
    ///   <para></para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entities"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
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