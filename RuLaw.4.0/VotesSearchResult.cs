using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Voting search results.</para>
  /// </summary>
  [Description("Voting search results")]
  [XmlType("result")]
  public class VotesSearchResult : IComparable<VotesSearchResult>
  {
    /// <summary>
    ///   <para>Total count of questions.</para>
    /// </summary>
    [Description("Total count of questions")]
    [JsonProperty("totalCount")]
    [XmlElement("totalCount")]
    public virtual int Count { get; set; }

    /// <summary>
    ///   <para>Number of results page.</para>
    /// </summary>
    [Description("Number of results page")]
    [JsonProperty("page")]
    [XmlElement("page")]
    public virtual int Page { get; set; }

    /// <summary>
    ///   <para>Number of records per results page.</para>
    /// </summary>
    [Description("Number of records per results page")]
    [JsonProperty("pageSize")]
    [XmlElement("pageSize")]
    public virtual int PageSize { get; set; }

    /// <summary>
    ///   <para>List of resulting votes.</para>
    /// </summary>
    [Description("List of resulting votes")]
    [JsonProperty("votes")]
    [XmlElement("vote")]
    public virtual List<Vote> Votes { get; set; }

    /// <summary>
    ///   <para>Text query formulation.</para>
    /// </summary>
    [Description("Text query formulation")]
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
    ///   <para>Compares the current vote search with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="VotesSearchResult"/> to compare with this instance.</param>
    public virtual int CompareTo(VotesSearchResult other)
    {
      return this.Count.CompareTo(other.Count);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current vote search.</para>
    /// </summary>
    /// <returns>A string that represents the current vote search.</returns>
    public override string ToString()
    {
      return this.Wording;
    }
  }
}