namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="INameable"/> interface.</para>
/// </summary>
/// <seealso cref="INameable"/>
public static class INameableExtensions
{
  /// <param name="entities">Source sequence of entities to filter.</param>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  extension<TEntity>(IEnumerable<TEntity> entities) where TEntity : INameable
  {
    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with given name.</para>
    /// </summary>
    /// <param name="name">Name to search for.</param>
    /// <returns>Filtered sequence of entities with specified name.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Name(string name) => entities?.Where(entity => entity is not null && entity.Name == name) ?? throw new ArgumentNullException(nameof(entities));
  }
}