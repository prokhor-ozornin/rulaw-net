using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="Vote"/>.</para>
  /// </summary>
  /// <seealso cref="Vote"/>
  public static class VoteExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of votes, leaving those having a specified subject.</para>
    /// </summary>
    /// <param name="votes">Source sequence of votes for filtering.</param>
    /// <param name="subject">Subject to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of votes with specified subject.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="votes"/> or <paramref name="subject"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="subject"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<Vote> Subject(this IEnumerable<Vote> votes, string subject)
    {
      Assertion.NotNull(votes);
      Assertion.NotEmpty(subject);

      return votes.Where(vote => vote != null && vote.Subject.ToLowerInvariant().Contains(subject.ToLowerInvariant()));
    }

    /// <summary>
    ///   <para>Filters sequence of votes, leaving those that were successful.</para>
    /// </summary>
    /// <param name="votes">Source sequence of votes for filtering.</param>
    /// <returns>Filtered sequence of successfull votes.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="votes"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Vote> Successful(this IEnumerable<Vote> votes)
    {
      Assertion.NotNull(votes);

      return votes.Where(vote => vote != null && vote.Successful);
    }

    /// <summary>
    ///   <para>Filters sequence of votes, leaving those that were unsuccessful.</para>
    /// </summary>
    /// <param name="votes">Source sequence of votes for filtering.</param>
    /// <returns>Filtered sequence of unsuccessful votes.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="votes"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Vote> Unsuccessful(this IEnumerable<Vote> votes)
    {
      Assertion.NotNull(votes);

      return votes.Where(vote => vote != null && !vote.Successful);
    }
  }
}