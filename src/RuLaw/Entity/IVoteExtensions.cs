using Catharsis.Commons;

namespace RuLaw;

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
  public static bool Personal(this IVote vote) => !vote.PersonResult.IsEmpty();

  /// <summary>
  ///   <para>Returns result of deputy voting as instance of <see cref="VotePersonResult"/> enumeration.</para>
  /// </summary>
  /// <param name="vote">Vote instance.</param>
  /// <returns>Result of deputy voting, or a <c>null</c> reference if <see cref="PersonResult"/> property was not yet set.</returns>
  public static VotePersonResult? PersonResult(this IVote vote)
  {
    return vote.PersonResult?.ToLowerInvariant() switch
    {
      "for" => VotePersonResult.For, "against" => VotePersonResult.Against, "abstain" => VotePersonResult.Abstain, "absent" => VotePersonResult.Absent, _ => null
    };
  }

  /// <summary>
  ///   <para>Returns type of voting result as instance of <see cref="VoteResultType"/> enumeration.</para>
  /// </summary>
  /// <param name="vote">Vote instance.</param>
  /// <returns>Type of voting result, or a <c>null</c> reference if <see cref="ResultType"/> property was not yet set.</returns>
  public static VoteResultType? ResultType(this IVote vote)
  {
    return vote.ResultType?.ToLowerInvariant() switch
    {
      "количественное" => VoteResultType.Quantitative,
      "рейтинговое" => VoteResultType.Rating,
      "качественное" => VoteResultType.Qualitative,
      "альтернативное" => VoteResultType.Alternative,
      _ => null
    };
  }

  /// <summary>
  ///   <para>Filters sequence of votes, leaving those having a specified subject.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="votes">Source sequence of votes for filtering.</param>
  /// <param name="subject">Subject to search for (case-insensitive).</param>
  /// <returns>Filtered sequence of votes with specified subject.</returns>
  public static IEnumerable<TEntity?> Subject<TEntity>(this IEnumerable<TEntity?> votes, string subject) where TEntity : IVote => votes.Where(vote => vote?.Subject != null && vote.Subject.ToLowerInvariant().Contains(subject.ToLowerInvariant()));

  /// <summary>
  ///   <para>Filters sequence of votes, leaving those that were successful.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="votes">Source sequence of votes for filtering.</param>
  /// <returns>Filtered sequence of successful votes.</returns>
  public static IEnumerable<TEntity?> Successful<TEntity>(this IEnumerable<TEntity?> votes) where TEntity : IVote => votes.Where(vote => vote != null && vote.Successful.GetValueOrDefault());

  /// <summary>
  ///   <para>Filters sequence of votes, leaving those that were unsuccessful.</para>
  /// </summary>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  /// <param name="votes">Source sequence of votes for filtering.</param>
  /// <returns>Filtered sequence of unsuccessful votes.</returns>
  public static IEnumerable<TEntity?> Unsuccessful<TEntity>(this IEnumerable<TEntity?> votes) where TEntity : IVote => votes.Where(vote => vote != null && !vote.Successful.GetValueOrDefault());
}