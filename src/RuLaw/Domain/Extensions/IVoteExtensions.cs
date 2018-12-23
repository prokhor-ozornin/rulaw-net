using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IVote"/>.</para>
  /// </summary>
  /// <seealso cref="IVote"/>
  public static class IVoteExtensions
  {
    /// <summary>
    ///   <para>Whether the vote represents a faction, or a deputy result.</para>
    /// </summary>
    /// <param name="vote">Vote instances.</param>
    /// <returns><c>true</c> if <paramref name="vote"/> represents a deputy, <c>false</c> if it represents a faction.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="vote"/> is a <c>null</c> reference.</exception>
    public static bool Personal(this IVote vote)
    {
      Assertion.NotNull(vote);

      return !vote.PersonResult.IsEmpty();
    }

    /// <summary>
    ///   <para>Returns result of deputy voting as instance of <see cref="VotePersonResult"/> enumeration.</para>
    /// </summary>
    /// <param name="vote">Vote instance.</param>
    /// <returns>Result of deputy voting, or a <c>null</c> reference if <see cref="PersonResult"/> property was not yet set.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="vote"/> is a <c>null</c> reference.</exception>
    public static VotePersonResult? PersonResult(this IVote vote)
    {
      Assertion.NotNull(vote);

      if (vote.PersonResult.IsEmpty())
      {
        return null;
      }

      switch (vote.PersonResult.ToLowerInvariant())
      {
        case "for":
          return VotePersonResult.For;

        case "against":
          return VotePersonResult.Against;

        case "abstain":
          return VotePersonResult.Abstain;

        case "absent":
          return VotePersonResult.Absent;

        default:
          throw new InvalidOperationException();
      }
    }

    /// <summary>
    ///   <para>Returns type of voting result as instance of <see cref="VoteResultType"/> enumeration.</para>
    /// </summary>
    /// <param name="vote">Vote instance.</param>
    /// <returns>Type of voting result, or a <c>null</c> reference if <see cref="ResultType"/> property was not yet set.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="vote"/> is a <c>null</c> reference.</exception>
    public static VoteResultType? ResultType(this IVote vote)
    {
      Assertion.NotNull(vote);

      if (vote.ResultType.IsEmpty())
      {
        return null;
      }

      switch (vote.ResultType.ToLowerInvariant())
      {
        case "количественное":
          return VoteResultType.Quantitative;

        case "рейтинговое":
          return VoteResultType.Rating;

        case "качественное":
          return VoteResultType.Qualitative;

        case "альтернативное":
          return VoteResultType.Alternative;

        default:
          throw new InvalidOperationException();
      }
    }

    /// <summary>
    ///   <para>Filters sequence of votes, leaving those having a specified subject.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="votes">Source sequence of votes for filtering.</param>
    /// <param name="subject">Subject to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of votes with specified subject.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="votes"/> or <paramref name="subject"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="subject"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<ENTITY> Subject<ENTITY>(this IEnumerable<ENTITY> votes, string subject) where ENTITY : IVote
    {
      Assertion.NotNull(votes);
      Assertion.NotEmpty(subject);

      return votes.Where(vote => vote != null && vote.Subject.ToLowerInvariant().Contains(subject.ToLowerInvariant()));
    }

    /// <summary>
    ///   <para>Filters sequence of votes, leaving those that were successful.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="votes">Source sequence of votes for filtering.</param>
    /// <returns>Filtered sequence of successfull votes.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="votes"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<ENTITY> Successful<ENTITY>(this IEnumerable<ENTITY> votes) where ENTITY : IVote
    {
      Assertion.NotNull(votes);

      return votes.Where(vote => vote != null && vote.Successful);
    }

    /// <summary>
    ///   <para>Filters sequence of votes, leaving those that were unsuccessful.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities.</typeparam>
    /// <param name="votes">Source sequence of votes for filtering.</param>
    /// <returns>Filtered sequence of unsuccessful votes.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="votes"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<ENTITY> Unsuccessful<ENTITY>(this IEnumerable<ENTITY> votes) where ENTITY : IVote
    {
      Assertion.NotNull(votes);

      return votes.Where(vote => vote != null && !vote.Successful);
    }
  }
}