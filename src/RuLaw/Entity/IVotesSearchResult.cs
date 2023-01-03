namespace RuLaw;

/// <summary>
///   <para>Voting search results.</para>
/// </summary>
public interface IVotesSearchResult : IPageable, IComparable<IVotesSearchResult>
{
  /// <summary>
  ///   <para>Total count of questions.</para>
  /// </summary>
  int? Count { get; }

  /// <summary>
  ///   <para>Text query formulation.</para>
  /// </summary>
  string Wording { get; }

  /// <summary>
  ///   <para>List of resulting votes.</para>
  /// </summary>
  IEnumerable<IVote> Votes { get; }
}