namespace RuLaw;

/// <summary>
///   <para></para>
/// </summary>
public interface IVote : IEntity, IDateable, IComparable<IVote>, IEquatable<IVote>
{
  /// <summary>
  ///   <para>Subject of convocation.</para>
  /// </summary>
  string Subject { get; }

  /// <summary>
  ///   <para>Whether the law passed (true) or not (false) according to voting.</para>
  /// </summary>
  bool? Successful { get; }

  /// <summary>
  ///   <para>Type of voting result.</para>
  /// </summary>
  string ResultType { get; }

  /// <summary>
  ///   <para>Result of deputy voting.</para>
  /// </summary>
  string PersonResult { get; }

  /// <summary>
  ///   <para>Number of voted deputies in faction.</para>
  /// </summary>
  int? TotalVotesCount { get; }

  /// <summary>
  ///   <para>Count of deputies in a faction who have voted for.</para>
  /// </summary>
  int? ForVotesCount { get; }

  /// <summary>
  ///   <para>Count of deputies in a faction who have voted against.</para>
  /// </summary>
  int? AgainstVotesCount { get; }

  /// <summary>
  ///   <para>Count of abstained deputies in a faction.</para>
  /// </summary>
  int? AbstainVotesCount { get; }

  /// <summary>
  ///   <para>Count of absent (non-voted) deputies in a faction.</para>
  /// </summary>
  int? AbsentVotesCount { get; }
}