namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IPageable"/>.</para>
/// </summary>
/// <seealso cref="IPageable"/>
public static class IPageableExtensions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="TEntity"></typeparam>
  /// <param name="entities"></param>
  /// <param name="from"></param>
  /// <param name="to"></param>
  /// <returns></returns>
  public static IEnumerable<TEntity> Page<TEntity>(this IEnumerable<TEntity> entities, int? from = null, int? to = null) where TEntity : IPageable
  {
    if (entities is null) throw new ArgumentNullException(nameof(entities));

    if (from is not null)
    {
      entities = entities.Where(entity => entity is not null && entity.Page >= from);
    }

    if (to is not null)
    {
      entities = entities.Where(entity => entity is not null && ((entity.Page is not null && entity.Page <= to) || entity.Page is null));
    }

    return entities;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="TEntity"></typeparam>
  /// <param name="entities"></param>
  /// <param name="from"></param>
  /// <param name="to"></param>
  /// <returns></returns>
  public static IEnumerable<TEntity> PageSize<TEntity>(this IEnumerable<TEntity> entities, int? from = null, int? to = null) where TEntity : IPageable
  {
    if (entities is null) throw new ArgumentNullException(nameof(entities));

    if (from is not null)
    {
      entities = entities.Where(entity => entity is not null && entity.PageSize >= from);
    }

    if (to is not null)
    {
      entities = entities.Where(entity => entity is not null && ((entity.PageSize is not null && entity.PageSize <= to) || entity.PageSize is null));
    }

    return entities;
  }
}