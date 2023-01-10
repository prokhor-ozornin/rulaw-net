using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IDeputyRequest"/>.</para>
/// </summary>
/// <seealso cref="IDeputyRequest"/>
public static class IDeputyRequestExtensions
{
  /// <summary>
  ///   <para>Filters sequence of deputies requests, leaving those with a specified initiator.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="requests">Source sequence of requests to filter.</param>
  /// <param name="initiator">Full or partial name of initiator to search for (case-insensitive).</param>
  /// <returns>Filtered sequence of requests with specified initiator.</returns>
  public static IEnumerable<TEntity> Initiator<TEntity>(this IEnumerable<TEntity> requests, string initiator) where TEntity : IDeputyRequest
  {
    if (requests is null) throw new ArgumentNullException(nameof(requests));
    if (initiator is null) throw new ArgumentNullException(nameof(initiator));
    if (initiator.IsEmpty()) throw new ArgumentException(nameof(initiator));

    return requests.Where(request => request != null && request.Initiator.ToLowerInvariant().Contains(initiator.ToLowerInvariant()));
  }

  /// <summary>
  ///   <para>Filters sequence of deputies requests, leaving those containing specified text fragment.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="requests">Source sequence of requests to filter.</param>
  /// <param name="text">Text fragment to search for (case-insensitive).</param>
  /// <returns>Filtered sequence of requests that contain specified text.</returns>
  public static IEnumerable<TEntity> Answer<TEntity>(this IEnumerable<TEntity> requests, string text) where TEntity : IDeputyRequest
  {
    if (requests is null) throw new ArgumentNullException(nameof(requests));
    if (text is null) throw new ArgumentNullException(nameof(text));
    if (text.IsEmpty()) throw new ArgumentException(nameof(text));

    return requests.Where(quest => quest != null && quest.Answer.ToLowerInvariant().Contains(text.ToLowerInvariant()));
  }

  /// <summary>
  ///   <para>Filters sequence of deputies requests, leaving those with signing date in specified borders.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="requests">Source sequence of requests to filter.</param>
  /// <param name="from">Lower bound of signing date period.</param>
  /// <param name="to">Upper bound of signing date period.</param>
  /// <returns>Filtered sequence of requests.</returns>
  public static IEnumerable<TEntity> SignDate<TEntity>(this IEnumerable<TEntity> requests, DateTimeOffset? from = null, DateTimeOffset? to = null) where TEntity : IDeputyRequest
  {
    if (requests is null) throw new ArgumentNullException(nameof(requests));

    if (from != null)
    {
      requests = requests.Where(request => request != null && request.SignDate >= from.Value);
    }

    if (to != null)
    {
      requests = requests.Where(request => request != null && request.SignDate <= to.Value);
    }

    return requests;
  }

  /// <summary>
  ///   <para>Filters sequence of deputies requests, leaving those with control date in specified borders.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="requests">Source sequence of requests to filter.</param>
  /// <param name="from">Lower bound of control date period.</param>
  /// <param name="to">Upper bound of control date period.</param>
  /// <returns>Filtered sequence of requests.</returns>
  public static IEnumerable<TEntity> ControlDate<TEntity>(this IEnumerable<TEntity> requests, DateTimeOffset? from = null, DateTimeOffset? to = null) where TEntity : IDeputyRequest
  {
    if (requests is null) throw new ArgumentNullException(nameof(requests));

    if (from != null)
    {
      requests = requests.Where(request => request != null && request.ControlDate >= from.Value);
    }

    if (to != null)
    {
      requests = requests.Where(request => request != null && request.ControlDate <= to.Value);
    }

    return requests;
  }
}