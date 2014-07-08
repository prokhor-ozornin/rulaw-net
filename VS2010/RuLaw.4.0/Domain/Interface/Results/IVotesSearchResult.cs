using System.Collections.Generic;

namespace RuLaw
{
  /// <summary>
  ///   <para>Voting search results.</para>
  /// </summary>
  public interface IVotesSearchResult
  {
    /// <summary>
    ///   <para>Total count of questions.</para>
    /// </summary>
    int Count { get; }

    /// <summary>
    ///   <para>Number of results page.</para>
    /// </summary>
    int Page { get; }

    /// <summary>
    ///   <para>Number of records per results page.</para>
    /// </summary>
    int PageSize { get; }

    /// <summary>
    ///   <para>List of resulting votes.</para>
    /// </summary>
    IEnumerable<IVote> Votes { get; }

    /// <summary>
    ///   <para>Text query formulation.</para>
    /// </summary>
    string Wording { get; }
  }
}