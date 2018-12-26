namespace RuLaw
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Catharsis.Commons;

  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IActive"/>.</para>
  /// </summary>
  public static class IActiveExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of entities, leaving those in active state.</para>
    /// </summary>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <returns>Filtered sequence of entities in active state.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IQueryable<ENTITY> Active<ENTITY>(this IQueryable<ENTITY> entities) where ENTITY : IActive
    {
      Assertion.NotNull(entities);

      return entities.Where(entity => entity.Active);
    }

    /// <summary>
    ///   <para>Filters sequence of entities, leaving those in active state.</para>
    /// </summary>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <returns>Filtered sequence of entities in active state.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<ENTITY> Active<ENTITY>(this IEnumerable<ENTITY> entities) where ENTITY : IActive
    {
      Assertion.NotNull(entities);

      return entities.Where(entity => entity != null && entity.Active);
    }

    /// <summary>
    ///   <para>Filters sequence of entities, leaving those in inactive state.</para>
    /// </summary>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <returns>Filtered sequence of entities in inactive state.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IQueryable<ENTITY> Inactive<ENTITY>(this IQueryable<ENTITY> entities) where ENTITY : IActive
    {
      Assertion.NotNull(entities);

      return entities.Where(entity => !entity.Active);
    }

    /// <summary>
    ///   <para>Filters sequence of entities, leaving those in inactive state.</para>
    /// </summary>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <returns>Filtered sequence of entities in inactive state.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<ENTITY> Inactive<ENTITY>(this IEnumerable<ENTITY> entities) where ENTITY : IActive
    {
      Assertion.NotNull(entities);

      return entities.Where(entity => entity != null && !entity.Active);
    }
  }
}