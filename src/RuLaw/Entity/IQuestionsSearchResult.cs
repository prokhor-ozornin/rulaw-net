namespace RuLaw;

/// <summary>
///   <para>Result of questions search.</para>
/// </summary>
public interface IQuestionsSearchResult : IPageable, IComparable<IQuestionsSearchResult>
{
  /// <summary>
  ///   <para>Number of result questions.</para>
  /// </summary>
  int? Count { get; }

  /// <summary>
  ///   <para>List of questions.</para>
  /// </summary>
  IEnumerable<IQuestion> Questions { get; }
}