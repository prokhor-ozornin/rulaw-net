using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>Result of questions search.</para>
/// </summary>
public sealed class QuestionsSearchResult : IQuestionsSearchResult
{
  /// <summary>
  ///   <para>Number of results page.</para>
  /// </summary>
  public int? Page { get; }

  /// <summary>
  ///   <para>Number of records per page.</para>
  /// </summary>
  public int? PageSize { get; }

  /// <summary>
  ///   <para>Number of result questions.</para>
  /// </summary>
  public int? Count { get; }

  /// <summary>
  ///   <para>List of questions.</para>
  /// </summary>
  public IEnumerable<IQuestion> Questions { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="page"></param>
  /// <param name="pageSize"></param>
  /// <param name="count"></param>
  /// <param name="questions"></param>
  public QuestionsSearchResult(int? page = null,
                               int? pageSize = null,
                               int? count = null,
                               IEnumerable<IQuestion> questions = null)
  {
    Page = page;
    PageSize = pageSize;
    Count = count;
    Questions = questions ?? [];
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public QuestionsSearchResult(Info info)
  {
    Page = info.Page;
    PageSize = info.PageSize;
    Count = info.Count;
    Questions = info.Questions ?? [];
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="info"></param>
  public QuestionsSearchResult(object info) : this(new Info().SetState(info)) {}

  /// <summary>
  ///   <para>Compares the current <see cref="IQuestionsSearchResult"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="IQuestionsSearchResult"/> to compare with this instance.</param>
  public int CompareTo(IQuestionsSearchResult other) => Nullable.Compare(Count, other?.Count);

  /// <summary>
  ///   <para></para>
  /// </summary>
  [DataContract(Name = "result")]
  public sealed record Info : IResultable<IQuestionsSearchResult>
  {
    /// <summary>
    ///   <para>Number of results page.</para>
    /// </summary>
    [DataMember(Name = "page", IsRequired = true)]
    public int? Page { get; init; }

    /// <summary>
    ///   <para>Number of records per page.</para>
    /// </summary>
    [DataMember(Name = "pageSize", IsRequired = true)]
    public int? PageSize { get; init; }

    /// <summary>
    ///   <para>Number of result questions.</para>
    /// </summary>
    [DataMember(Name = "totalCount", IsRequired = true)]
    public int? Count { get; init; }

    /// <summary>
    ///   <para>List of questions.</para>
    /// </summary>
    [DataMember(Name = "questions", IsRequired = true)]
    public List<Question> Questions { get; init; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <returns></returns>
    public IQuestionsSearchResult ToResult() => new QuestionsSearchResult(this);
  }
}