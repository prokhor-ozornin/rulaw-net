using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Result of questions search.</para>
  /// </summary>
  [Description("Result of questions search")]
  [XmlType("result")]
  public sealed class QuestionsSearchResult : IComparable<QuestionsSearchResult>
  {
    /// <summary>
    ///   <para>Number of result questions.</para>
    /// </summary>
    [Description("Number of result questions")]
    [JsonProperty("totalCount")]
    [XmlElement("totalCount")]
    public int Count { get; set; }

    /// <summary>
    ///   <para>Number of results page.</para>
    /// </summary>
    [Description("Number of results page")]
    [JsonProperty("page")]
    [XmlElement("page")]
    public int Page { get; set; }

    /// <summary>
    ///   <para>Number of records per page.</para>
    /// </summary>
    [Description("Number of records per page")]
    [JsonProperty("pageSize")]
    [XmlElement("pageSize")]
    public int PageSize { get; set; }

    /// <summary>
    ///   <para>List of questions.</para>
    /// </summary>
    [Description("List of questions")]
    [JsonProperty("questions")]
    [XmlElement("question")]
    public List<Question> Questions { get; set; }

    /// <summary>
    ///   <para>Creates new result of questions search.</para>
    /// </summary>
    public QuestionsSearchResult()
    {
      this.Questions = new List<Question>();
    }

    /// <summary>
    ///   <para>Compares the current questions search with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="LawsSearchResult"/> to compare with this instance.</param>
    public int CompareTo(QuestionsSearchResult other)
    {
      return this.Count.CompareTo(other.Count);
    }
  }
}