namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IPageable"/> interface.</para>
/// </summary>
/// <seealso cref="IPageable"/>
public static class IPageableExtensions
{
  /// <param name="entities"></param>
  /// <typeparam name="TEntity"></typeparam>
  extension<TEntity>(IEnumerable<TEntity> entities) where TEntity : IPageable
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Page(int? from = null, int? to = null)
    {
      if (entities is null) throw new ArgumentNullException(nameof(entities));

      if (from is not null)
      {
        entities = entities.Where(entity => entity is not null && entity.Page >= from);
      }

      if (to is not null)
      {
        entities = entities.Where(entity => entity is not null && (entity.Page is null || entity.Page <= to));
      }

      return entities;
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> PageSize(int? from = null, int? to = null)
    {
      if (entities is null) throw new ArgumentNullException(nameof(entities));

      if (from is not null)
      {
        entities = entities.Where(entity => entity is not null && entity.PageSize >= from);
      }

      if (to is not null)
      {
        entities = entities.Where(entity => entity is not null && (entity.PageSize is null || entity.PageSize <= to));
      }

      return entities;
    }
  }
}