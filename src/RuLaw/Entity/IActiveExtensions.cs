namespace RuLaw;

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
  public static IEnumerable<TEntity> Active<TEntity>(this IEnumerable<TEntity> entities) where TEntity : IActive => entities is not null ? entities.Where(entity => entity is {Active: true}) : throw new ArgumentNullException(nameof(entities));

  /// <summary>
  ///   <para>Filters sequence of entities, leaving those in inactive state.</para>
  /// </summary>
  /// <param name="entities">Source sequence of entities to filter.</param>
  /// <returns>Filtered sequence of entities in inactive state.</returns>
  public static IEnumerable<TEntity> Inactive<TEntity>(this IEnumerable<TEntity> entities) where TEntity : IActive => entities is not null ? entities.Where(entity => entity is {Active: false}) : throw new ArgumentNullException(nameof(entities));
}