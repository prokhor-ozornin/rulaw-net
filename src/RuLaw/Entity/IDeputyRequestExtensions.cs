using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IDeputyRequest"/> interface.</para>
/// </summary>
/// <seealso cref="IDeputyRequest"/>
public static class IDeputyRequestExtensions
{
  /// <param name="requests">Source sequence of requests to filter.</param>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  extension<TEntity>(IEnumerable<TEntity> requests) where TEntity : IDeputyRequest
  {
    /// <summary>
    ///   <para>Filters sequence of deputies requests, leaving those with a specified initiator.</para>
    /// </summary>
    /// <param name="initiator">Full or partial name of initiator to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of requests with specified initiator.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="requests"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Initiator(string initiator) => requests?.Where(request => request is not null && request.Initiator.ToInvariantString().Contains(initiator.ToInvariantString())) ?? throw new ArgumentNullException(nameof(requests));

    /// <summary>
    ///   <para>Filters sequence of deputies requests, leaving those containing specified text fragment.</para>
    /// </summary>
    /// <param name="text">Text fragment to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of requests that contain specified text.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="requests"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Answer(string text) => requests?.Where(request => request is not null && request.Answer.ToInvariantString().Contains(text.ToInvariantString())) ?? throw new ArgumentNullException(nameof(requests));

    /// <summary>
    ///   <para>Filters sequence of deputies requests, leaving those with signing date in specified borders.</para>
    /// </summary>
    /// <param name="from">Lower bound of signing date period.</param>
    /// <param name="to">Upper bound of signing date period.</param>
    /// <returns>Filtered sequence of requests.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="requests"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> SignDate(DateTimeOffset? from = null, DateTimeOffset? to = null)
    {
      if (requests is null) throw new ArgumentNullException(nameof(requests));

      if (from is not null)
      {
        requests = requests.Where(request => request is not null && request.SignDate >= from.Value);
      }

      if (to is not null)
      {
        requests = requests.Where(request => request is not null && request.SignDate <= to.Value);
      }

      return requests;
    }

    /// <summary>
    ///   <para>Filters sequence of deputies requests, leaving those with control date in specified borders.</para>
    /// </summary>
    /// <param name="from">Lower bound of control date period.</param>
    /// <param name="to">Upper bound of control date period.</param>
    /// <returns>Filtered sequence of requests.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="requests"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> ControlDate(DateTimeOffset? from = null, DateTimeOffset? to = null)
    {
      if (requests is null) throw new ArgumentNullException(nameof(requests));

      if (from is not null)
      {
        requests = requests.Where(request => request is not null && request.ControlDate >= from.Value);
      }

      if (to is not null)
      {
        requests = requests.Where(request => request is not null && request.ControlDate <= to.Value);
      }

      return requests;
    }
  }
}