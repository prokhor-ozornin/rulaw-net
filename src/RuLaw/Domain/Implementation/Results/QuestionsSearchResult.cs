namespace RuLaw
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Serialization;
  using Newtonsoft.Json;

  /// <summary>
  ///   <para>Result of questions search.</para>
  /// </summary>
  [XmlType("result")]
  public sealed class QuestionsSearchResult : IComparable<IQuestionsSearchResult>, IQuestionsSearchResult
  {
    /// <summary>
    ///   <para>Number of result questions.</para>
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
    ///   <para>Number of records per page.</para>
    /// </summary>
    [JsonProperty("pageSize")]
    [XmlElement("pageSize")]
    public int PageSize { get; set; }

    /// <summary>
    ///   <para>List of questions.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<IQuestion> Questions
    {
      get { return QuestionsOriginal.Cast<IQuestion>(); }
    }

    /// <summary>
    ///   <para>List of questions.</para>
    /// </summary>
    [JsonProperty("questions")]
    [XmlElement("question")]
    public List<Question> QuestionsOriginal { get; set; }

    /// <summary>
    ///   <para>Creates new result of questions search.</para>
    /// </summary>
    public QuestionsSearchResult()
    {
      QuestionsOriginal = new List<Question>();
    }

    /// <summary>
    ///   <para>Compares the current <see cref="IQuestionsSearchResult"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="IQuestionsSearchResult"/> to compare with this instance.</param>
    public int CompareTo(IQuestionsSearchResult other)
    {
      return Count.CompareTo(other.Count);
    }
  }
}