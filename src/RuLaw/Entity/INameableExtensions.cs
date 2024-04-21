namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="INameable"/>.</para>
/// </summary>
/// <seealso cref="INameable"/>
public static class INameableExtensions
{
  /// <summary>
  ///   <para>Filters sequence of entities, leaving those with given name.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="entities">Source sequence of entities to filter.</param>
  /// <param name="name">Name to search for.</param>
  /// <returns>Filtered sequence of entities with specified name.</returns>
  public static IEnumerable<TEntity> Name<TEntity>(this IEnumerable<TEntity> entities, string name) where TEntity : INameable => entities is not null ? entities.Where(entity => entity is not null && entity.Name == name) : throw new ArgumentNullException(nameof(entities));
}