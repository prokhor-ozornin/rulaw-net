using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IVote"/> interface.</para>
/// </summary>
/// <seealso cref="IVote"/>
public static class IVoteExtensions
{
  /// <param name="vote">Vote instances.</param>
  extension(IVote vote)
  {
    /// <summary>
    ///   <para>Whether the vote represents a faction, or a deputy result.</para>
    /// </summary>
    /// <value>
    ///   <c>true</c> if <paramref name="vote"/> represents a deputy, <c>false</c> if it represents a faction.
    /// </value>
    /// <exception cref="ArgumentNullException">If <paramref name="vote"/> is <see langword="null"/>.</exception>
    public bool Personal => !(vote?.PersonResult)?.IsUnset() ?? throw new ArgumentNullException(nameof(vote));

    /// <summary>
    ///   <para>Returns result of deputy voting as instance of <see cref="VotePersonResult"/> enumeration.</para>
    /// </summary>
    /// <value>Result of deputy voting, or a <c>null</c> reference if <see cref="VotePersonResult"/> property was not yet set.</value>
    /// <exception cref="ArgumentNullException">If <paramref name="vote"/> is <see langword="null"/>.</exception>
    public VotePersonResult? VotePersonResult
    {
      get
      {
        if (vote is null) throw new ArgumentNullException(nameof(vote));

        return vote.PersonResult?.ToLowerInvariant() switch
        {
          "for" => VotePersonResult.For, "against" => VotePersonResult.Against, "abstain" => VotePersonResult.Abstain, "absent" => VotePersonResult.Absent, _ => null
        };
      }
    }

    /// <summary>
    ///   <para>Returns type of voting result as instance of <see cref="VoteResultType"/> enumeration.</para>
    /// </summary>
    /// <value>Type of voting result, or a <c>null</c> reference if <see cref="VoteResultType"/> property was not yet set.</value>
    /// <exception cref="ArgumentNullException">If <paramref name="vote"/> is <see langword="null"/>.</exception>
    public VoteResultType? VoteResultType
    {
      get
      {
        if (vote is null) throw new ArgumentNullException(nameof(vote));

        return vote.ResultType?.ToLowerInvariant() switch
        {
          "количественное" => VoteResultType.Quantitative, "рейтинговое" => VoteResultType.Rating, "качественное" => VoteResultType.Qualitative, "альтернативное" => VoteResultType.Alternative, _ => null
        };
      }
    }
  }

  /// <param name="votes">Source sequence of votes for filtering.</param>
  /// <typeparam name="TEntity">Type of entities.</typeparam>
  extension<TEntity>(IEnumerable<TEntity> votes) where TEntity : IVote
  {
    /// <summary>
    ///   <para>Filters sequence of votes, leaving those having a specified subject.</para>
    /// </summary>
    /// <param name="subject">Subject to search for (case-insensitive).</param>
    /// <returns>Filtered sequence of votes with specified subject.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="votes"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Subject(string subject) => votes?.Where(vote => vote?.Subject is not null && vote.Subject.ToInvariantString().Contains(subject.ToInvariantString())) ?? throw new ArgumentNullException(nameof(votes));

    /// <summary>
    ///   <para>Filters sequence of votes, leaving those that were successful.</para>
    /// </summary>
    /// <value>Filtered sequence of successful votes.</value>
    /// <exception cref="ArgumentNullException">If <paramref name="votes"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Successful => votes?.Where(vote => vote is not null && vote.Successful.GetValueOrDefault()) ?? throw new ArgumentNullException(nameof(votes));

    /// <summary>
    ///   <para>Filters sequence of votes, leaving those that were unsuccessful.</para>
    /// </summary>
    /// <value>Filtered sequence of unsuccessful votes.</value>
    /// <exception cref="ArgumentNullException">If <paramref name="votes"/> is <see langword="null"/>.</exception>
    public IEnumerable<TEntity> Unsuccessful => votes?.Where(vote => vote is not null && !vote.Successful.GetValueOrDefault()) ?? throw new ArgumentNullException(nameof(votes));
  }
}