namespace RuLaw
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Catharsis.Commons;

  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="ILawEvent"/>.</para>
  /// </summary>
  /// <seealso cref="ILawEvent"/>
  public static class ILawEventExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of law's events, leaving those having a specified resulting solution.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="events">Source sequence of events to filter.</param>
    /// <param name="solution">Solution to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of events having a specified solution.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="events"/> or <paramref name="solution"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="solution"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<ENTITY> Solution<ENTITY>(this IEnumerable<ENTITY> events, string solution) where ENTITY : ILawEvent
    {
      Assertion.NotNull(events);
      Assertion.NotEmpty(solution);

      return events.Where(@event => @event != null && @event.Solution.ToLowerInvariant().Contains(solution.ToLowerInvariant()));
    }
  }
}