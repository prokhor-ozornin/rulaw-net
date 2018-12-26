namespace RuLaw
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Serialization;
  using Newtonsoft.Json;

  /// <summary>
  ///   <para>Voting search results.</para>
  /// </summary>
  [XmlType("result")]
  public sealed class VotesSearchResult : IComparable<IVotesSearchResult>, IVotesSearchResult
  {
    /// <summary>
    ///   <para>Total count of questions.</para>
    /// </summary>
    [JsonProperty("totalCount")]
    [XmlElement("totalCount")]
    public int Count { get; set; }

    /// <summary>
    ///   <para>Number of results page.</para>
    /// </summary>
    [JsonProperty("page")]
    [XmlElement("page")]
    public int Page { get; set; }

    /// <summary>
    ///   <para>Number of records per results page.</para>
    /// </summary>
    [JsonProperty("pageSize")]
    [XmlElement("pageSize")]
    public int PageSize { get; set; }

    /// <summary>
    ///   <para>List of resulting votes.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<IVote> Votes
    {
      get { return VotesOriginal.Cast<IVote>(); }
    }

    /// <summary>
    ///   <para>List of resulting votes.</para>
    /// </summary>
    [JsonProperty("votes")]
    [XmlElement("vote")]
    public List<Vote> VotesOriginal { get; set; }

    /// <summary>
    ///   <para>Text query formulation.</para>
    /// </summary>
    [JsonProperty("wording")]
    [XmlElement("wording")]
    public string Wording { get; set; }

    /// <summary>
    ///   <para>Creates new voting search results.</para>
    /// </summary>
    public VotesSearchResult()
    {
      VotesOriginal = new List<Vote>();
    }

    /// <summary>
    ///   <para>Compares the current <see cref="IVotesSearchResult"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="IVotesSearchResult"/> to compare with this instance.</param>
    public int CompareTo(IVotesSearchResult other)
    {
      return Count.CompareTo(other.Count);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="VotesSearchResult"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="VotesSearchResult"/>.</returns>
    public override string ToString()
    {
      return Wording;
    }
  }
}