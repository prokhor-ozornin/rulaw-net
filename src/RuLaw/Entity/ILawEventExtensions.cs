using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="ILawEvent"/> interface.</para>
/// </summary>
/// <seealso cref="ILawEvent"/>
public static class ILawEventExtensions
{
  /// <param name="events">Source sequence of events to filter.</param>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  extension<TEntity>(IEnumerable<TEntity> events) where TEntity : ILawEvent
  {
    /// <summary>
    ///   <para>Filters sequence of law's events, leaving those having a specified resulting solution.</para>
    /// </summary>
    /// <param name="solution">Solution to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of events having a specified solution.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="events"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Solution(string solution) => events?.Where(lawEvent => lawEvent is not null && lawEvent.Solution.ToInvariantString().Contains(solution.ToInvariantString())) ?? throw new ArgumentNullException(nameof(events));
  }
}