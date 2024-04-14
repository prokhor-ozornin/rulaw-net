using System.Runtime.Serialization;

namespace RuLaw;

/// <summary>
///   <para>Voting search results.</para>
/// </summary>
[DataContract(Name = "result")]
public sealed class VotesSearchResult : IVotesSearchResult
{
  /// <summary>
  ///   <para>Number of results page.</para>
  /// </summary>
  [DataMember(Name = "page", IsRequired = true)]
  public int? Page { get; set; }

  /// <summary>
  ///   <para>Number of records per results page.</para>
  /// </summary>
  [DataMember(Name = "pageSize", IsRequired = true)]
  public int? PageSize { get; set; }

  /// <summary>
  ///   <para>Total count of questions.</para>
  /// </summary>
  [DataMember(Name = "totalCount", IsRequired = true)]
  public int? Count { get; set; }

  /// <summary>
  ///   <para>Text query formulation.</para>
  /// </summary>
  [DataMember(Name = "wording", IsRequired = true)]
  public string Wording { get; set; }

  /// <summary>
  ///   <para>List of resulting votes.</para>
  /// </summary>
  [DataMember(Name = "votes", IsRequired = true)]
  public IEnumerable<IVote> Votes { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="IVotesSearchResult"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="IVotesSearchResult"/> to compare with this instance.</param>
  public int CompareTo(IVotesSearchResult other) => Nullable.Compare(Count, other?.Count);

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current <see cref="VotesSearchResult"/> instance.</para>
  /// </summary>
  /// <returns>A string that represents the current <see cref="VotesSearchResult"/>.</returns>
  public override string ToString() => Wording ?? string.Empty;
}