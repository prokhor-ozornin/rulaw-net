using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="LawEvent"/>.</para>
  /// </summary>
  /// <seealso cref="LawEvent"/>
  public static class LawEventExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of law's events, leaving those having a specified resulting solution.</para>
    /// </summary>
    /// <param name="events">Source sequence of events to filter.</param>
    /// <param name="solution">Solution to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of events having a specified solution.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="events"/> or <paramref name="solution"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="solution"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<ILawEvent> Solution(this IEnumerable<ILawEvent> events, string solution)
    {
      Assertion.NotNull(events);
      Assertion.NotEmpty(solution);

      return events.Where(@event => @event != null && @event.Solution.ToLowerInvariant().Contains(solution.ToLowerInvariant()));
    }
  }
}