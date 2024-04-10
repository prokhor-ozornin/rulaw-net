using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Voting search results.</para>
/// </summary>
public sealed class VotesSearchResult : IVotesSearchResult
{
  /// <summary>
  ///   <para>Number of results page.</para>
  /// </summary>
  public int? Page { get; }

  /// <summary>
  ///   <para>Number of records per results page.</para>
  /// </summary>
  public int? PageSize { get; }

  /// <summary>
  ///   <para>Total count of questions.</para>
  /// </summary>
  public int? Count { get; }

  /// <summary>
  ///   <para>Text query formulation.</para>
  /// </summary>
  public string Wording { get; }

  /// <summary>
  ///   <para>List of resulting votes.</para>
  /// </summary>
  public IEnumerable<IVote> Votes { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="page"></param>
  /// <param name="pageSize"></param>
  /// <param name="count"></param>
  /// <param name="wording"></param>
  /// <param name="votes"></param>
  public VotesSearchResult(int? page = null,
                           int? pageSize = null,
                           int? count = null,
                           string wording = null,
                           IEnumerable<IVote> votes = null)
  {
    Page = page;
    PageSize = pageSize;
    Count = count;
    Wording = wording;
    Votes = votes ?? [];
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public VotesSearchResult(Info info)
  {
    Page = info.Page;
    PageSize = info.PageSize;
    Count = info.Count;
    Wording = info.Wording;
    Votes = info.Votes ?? [];
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public VotesSearchResult(object info) : this(new Info().SetState(info)) {}

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

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "result")]
  public sealed record Info : IResultable<IVotesSearchResult>
  {
    /// <summary>
    ///   <para>Number of results page.</para>
    /// </summary>
    [DataMember(Name = "page", IsRequired = true)]
    public int? Page { get; init; }

    /// <summary>
    ///   <para>Number of records per results page.</para>
    /// </summary>
    [DataMember(Name = "pageSize", IsRequired = true)]
    public int? PageSize { get; init; }

    /// <summary>
    ///   <para>Total count of questions.</para>
    /// </summary>
    [DataMember(Name = "totalCount", IsRequired = true)]
    public int? Count { get; init; }

    /// <summary>
    ///   <para>Text query formulation.</para>
    /// </summary>
    [DataMember(Name = "wording", IsRequired = true)]
    public string Wording { get; init; }

    /// <summary>
    ///   <para>List of resulting votes.</para>
    /// </summary>
    [DataMember(Name = "votes", IsRequired = true)]
    public List<Vote> Votes { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IVotesSearchResult ToResult() => new VotesSearchResult(this);
  }
}