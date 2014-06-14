using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Voting search results.</para>
  /// </summary>
  [XmlType("result")]
  public class VotesSearchResult : IComparable<VotesSearchResult>
  {
    /// <summary>
    ///   <para>Total count of questions.</para>
    /// </summary>
    [JsonProperty("totalCount")]
    [XmlElement("totalCount")]
    public virtual int Count { get; set; }

    /// <summary>
    ///   <para>Number of results page.</para>
    /// </summary>
    [JsonProperty("page")]
    [XmlElement("page")]
    public virtual int Page { get; set; }

    /// <summary>
    ///   <para>Number of records per results page.</para>
    /// </summary>
    [JsonProperty("pageSize")]
    [XmlElement("pageSize")]
    public virtual int PageSize { get; set; }

    /// <summary>
    ///   <para>List of resulting votes.</para>
    /// </summary>
    [JsonProperty("votes")]
    [XmlElement("vote")]
    public virtual List<Vote> Votes { get; set; }

    /// <summary>
    ///   <para>Text query formulation.</para>
    /// </summary>
    [JsonProperty("wording")]
    [XmlElement("wording")]
    public virtual string Wording { get; set; }

    /// <summary>
    ///   <para>Creates new voting search results.</para>
    /// </summary>
    public VotesSearchResult()
    {
      this.Votes = new List<Vote>();
    }

    /// <summary>
    ///   <para>Compares the current <see cref="VotesSearchResult"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="VotesSearchResult"/> to compare with this instance.</param>
    public virtual int CompareTo(VotesSearchResult other)
    {
      return this.Count.CompareTo(other.Count);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="VotesSearchResult"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="VotesSearchResult"/>.</returns>
    public override string ToString()
    {
      return this.Wording;
    }
  }
}