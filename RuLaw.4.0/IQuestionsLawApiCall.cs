using System;

namespace RuLaw
{
  /// <summary>
  ///   <para>Representation of sessions questions search request to Russian State Duma REST API.</para>
  /// </summary>
  public interface IQuestionsLawApiCall : IPagedLawApiCall<IQuestionsLawApiCall>, ILawApiCall
  {
    /// <summary>
    ///   <para>Specifies lower bound (min) date of sessions.</para>
    /// </summary>
    /// <param name="date">Sessions date.</param>
    /// <returns>Back reference to the current request.</returns>
    IQuestionsLawApiCall From(DateTime date);

    /// <summary>
    ///   <para>Specifies name of questions.</para>
    /// </summary>
    /// <param name="name">Full or partial name of questions.</param>
    /// <returns>Back reference to the current request.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    IQuestionsLawApiCall Name(string name);

    /// <summary>
    ///   <para>Specifies upper bound (max) date of sessions.</para>
    /// </summary>
    /// <param name="date">Sessions date.</param>
    /// <returns>Back reference to the current request.</returns>
    IQuestionsLawApiCall To(DateTime date);
  }
}