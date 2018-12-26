namespace RuLaw
{
  using System.Collections.Generic;

  /// <summary>
  ///   <para>Result of questions search.</para>
  /// </summary>
  public interface IQuestionsSearchResult
  {
    /// <summary>
    ///   <para>Number of result questions.</para>
    /// </summary>
    int Count { get; }

    /// <summary>
    ///   <para>Number of results page.</para>
    /// </summary>
    int Page { get; }

    /// <summary>
    ///   <para>Number of records per page.</para>
    /// </summary>
    int PageSize { get; }

    /// <summary>
    ///   <para>List of questions.</para>
    /// </summary>
    IEnumerable<IQuestion> Questions { get; }
  }
}