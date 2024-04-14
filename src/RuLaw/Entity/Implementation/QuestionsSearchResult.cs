using System.Runtime.Serialization;

namespace RuLaw;

/// <summary>
///   <para>Result of questions search.</para>
/// </summary>
[DataContract(Name = "result")]
public sealed class QuestionsSearchResult : IQuestionsSearchResult
{
  /// <summary>
  ///   <para>Number of results page.</para>
  /// </summary>
  [DataMember(Name = "page", IsRequired = true)]
  public int? Page { get; set; }

  /// <summary>
  ///   <para>Number of records per page.</para>
  /// </summary>
  [DataMember(Name = "pageSize", IsRequired = true)]
  public int? PageSize { get; set; }

  /// <summary>
  ///   <para>Number of result questions.</para>
  /// </summary>
  [DataMember(Name = "totalCount", IsRequired = true)]
  public int? Count { get; set; }

  /// <summary>
  ///   <para>List of questions.</para>
  /// </summary>
  [DataMember(Name = "questions", IsRequired = true)]
  public IEnumerable<IQuestion> Questions { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="IQuestionsSearchResult"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="IQuestionsSearchResult"/> to compare with this instance.</param>
  public int CompareTo(IQuestionsSearchResult other) => Nullable.Compare(Count, other?.Count);
}