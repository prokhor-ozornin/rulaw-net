using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="ILawEvent"/>.</para>
/// </summary>
/// <seealso cref="ILawEvent"/>
public static class ILawEventExtensions
{
  /// <summary>
  ///   <para>Filters sequence of law's events, leaving those having a specified resulting solution.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="events">Source sequence of events to filter.</param>
  /// <param name="solution">Solution to search for (case-insensitive).</param>
  /// <returns>Filtered sequence of events having a specified solution.</returns>
  public static IEnumerable<TEntity> Solution<TEntity>(this IEnumerable<TEntity> events, string solution) where TEntity : ILawEvent
  {
    if (events is null) throw new ArgumentNullException(nameof(events));

    return events.Where(lawEvent => lawEvent is not null && lawEvent.Solution.ToInvariantString().Contains(solution.ToInvariantString()));
  }
}