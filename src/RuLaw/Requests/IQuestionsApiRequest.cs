namespace RuLaw;

/// <summary>
///   <para>Representation of sessions questions search request to Russian State Duma REST API.</para>
/// </summary>
public interface IQuestionsApiRequest : IPagedApiRequest<IQuestionsApiRequest>, IApiRequest
{
  /// <summary>
  ///   <para>Specifies name of questions.</para>
  /// </summary>
  /// <param name="name">Full or partial name of questions.</param>
  /// <returns>Back reference to the current request.</returns>
  IQuestionsApiRequest Name(string name);

  /// <summary>
  ///   <para>Specifies lower bound (min) date of sessions.</para>
  /// </summary>
  /// <param name="date">Sessions date.</param>
  /// <returns>Back reference to the current request.</returns>
  IQuestionsApiRequest FromDate(DateTimeOffset? date);

  /// <summary>
  ///   <para>Specifies upper bound (max) date of sessions.</para>
  /// </summary>
  /// <param name="date">Sessions date.</param>
  /// <returns>Back reference to the current request.</returns>
  IQuestionsApiRequest ToDate(DateTimeOffset? date);
}