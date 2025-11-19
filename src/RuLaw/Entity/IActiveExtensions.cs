namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IActive"/> interface.</para>
/// </summary>
public static class IActiveExtensions
{
  /// <param name="entities">Source sequence of entities to filter.</param>
  extension<TEntity>(IEnumerable<TEntity> entities) where TEntity : IActive
  {
    /// <summary>
    ///   <para>Filters sequence of entities, leaving those in active state.</para>
    /// </summary>
    /// <returns>Filtered sequence of entities in active state.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Active() => entities?.Where(entity => entity is {Active: true}) ?? throw new ArgumentNullException(nameof(entities));

    /// <summary>
    ///   <para>Filters sequence of entities, leaving those in inactive state.</para>
    /// </summary>
    /// <returns>Filtered sequence of entities in inactive state.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Inactive() => entities?.Where(entity => entity is {Active: false}) ?? throw new ArgumentNullException(nameof(entities));
  }
}