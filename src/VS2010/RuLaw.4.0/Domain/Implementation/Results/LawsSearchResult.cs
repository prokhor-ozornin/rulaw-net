using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Result of laws search.</para>
  /// </summary>
  [XmlType("result")]
  public sealed class LawsSearchResult : IComparable<ILawsSearchResult>, ILawsSearchResult
  {
    /// <summary>
    ///   <para>Number of result laws.</para>
    /// </summary>
    [JsonProperty("count")]
    [XmlElement("count")]
    public int Count { get; set; }

    /// <summary>
    ///   <para>List of result laws.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<ILaw> Laws
    {
      get { return this.LawsOriginal.Cast<ILaw>(); }
    }

    /// <summary>
    ///   <para>List of result laws.</para>
    /// </summary>
    [JsonProperty("laws")]
    [XmlElement("law")]
    public List<Law> LawsOriginal { get; set; }

    /// <summary>
    ///   <para>Number of results page.</para>
    /// </summary>
    [JsonProperty("page")]
    [XmlElement("page")]
    public int Page { get; set; }

    /// <summary>
    ///   <para>Text query formulation.</para>
    /// </summary>
    [JsonProperty("wording")]
    [XmlElement("wording")]
    public string Wording { get; set; }

    /// <summary>
    ///   <para>Creates new result of laws search.</para>
    /// </summary>
    public LawsSearchResult()
    {
      this.LawsOriginal = new List<Law>();
    }

    /// <summary>
    ///   <para>Compares the current <see cref="ILawsSearchResult"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="ILawsSearchResult"/> to compare with this instance.</param>
    public int CompareTo(ILawsSearchResult other)
    {
      return this.Count.CompareTo(other.Count);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="LawsSearchResult"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="LawsSearchResult"/>.</returns>
    public override string ToString()
    {
      return this.Wording;
    }
  }
}