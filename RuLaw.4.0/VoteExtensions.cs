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
    ///   <para></para>
    /// </summary>
    /// <param name="votes"></param>
    /// <param name="subject"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="votes"/> or <paramref name="subject"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="subject"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<Vote> Subject(this IEnumerable<Vote> votes, string subject)
    {
      Assertion.NotNull(votes);
      Assertion.NotEmpty(subject);

      return votes.Where(vote => vote != null && vote.Subject.ToLowerInvariant().Contains(subject.ToLowerInvariant()));
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="votes"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="votes"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Vote> Successful(this IEnumerable<Vote> votes)
    {
      Assertion.NotNull(votes);

      return votes.Where(vote => vote != null && vote.Successful);
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="votes"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="votes"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Vote> Unsuccessful(this IEnumerable<Vote> votes)
    {
      Assertion.NotNull(votes);

      return votes.Where(vote => vote != null && !vote.Successful);
    }
  }
}