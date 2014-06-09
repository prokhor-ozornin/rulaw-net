using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Result of laws search.</para>
  /// </summary>
  [Description("Result of laws search")]
  [XmlType("result")]
  public sealed class LawsSearchResult : IComparable<LawsSearchResult>
  {
    /// <summary>
    ///   <para>Number of result laws.</para>
    /// </summary>
    [Description("Number of result laws")]
    [JsonProperty("count")]
    [XmlElement("count")]
    public int Count { get; set; }

    /// <summary>
    ///   <para>List of result laws.</para>
    /// </summary>
    [Description("List of result laws")]
    [JsonProperty("laws")]
    [XmlElement("law")]
    public List<Law> Laws { get; set; }

    /// <summary>
    ///   <para>Number of results page.</para>
    /// </summary>
    [Description("Number of results page")]
    [JsonProperty("page")]
    [XmlElement("page")]
    public int Page { get; set; }

    /// <summary>
    ///   <para>Text query formulation.</para>
    /// </summary>
    [Description("Text query formulation")]
    [JsonProperty("wording")]
    [XmlElement("wording")]
    public string Wording { get; set; }

    /// <summary>
    ///   <para>Creates new result of laws search.</para>
    /// </summary>
    public LawsSearchResult()
    {
      this.Laws = new List<Law>();
    }

    /// <summary>
    ///   <para>Compares the current laws search result with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="LawsSearchResult"/> to compare with this instance.</param>
    public int CompareTo(LawsSearchResult other)
    {
      return this.Count.CompareTo(other.Count);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current laws search result.</para>
    /// </summary>
    /// <returns>A string that represents the current laws search result.</returns>
    public override string ToString()
    {
      return this.Wording;
    }
  }
}