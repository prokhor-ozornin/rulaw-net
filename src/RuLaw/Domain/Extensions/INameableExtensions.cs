namespace RuLaw
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Catharsis.Commons;

  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="INameable"/>.</para>
  /// </summary>
  /// <seealso cref="INameable"/>
  public static class INameableExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with given name.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="name">Name to search for.</param>
    /// <returns>Filtered sequence of entities with specified name.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IQueryable<ENTITY> Name<ENTITY>(this IQueryable<ENTITY> entities, string name) where ENTITY : INameable
    {
      Assertion.NotNull(entities);

      return entities.Where(entity => entity.Name == name);
    }

    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with given name.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="name">Name to search for.</param>
    /// <returns>Filtered sequence of entities with specified name.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<ENTITY> Name<ENTITY>(this IEnumerable<ENTITY> entities, string name) where ENTITY : INameable
    {
      Assertion.NotNull(entities);

      return entities.Where(entity => entity != null && entity.Name == name);
    }
  }
}