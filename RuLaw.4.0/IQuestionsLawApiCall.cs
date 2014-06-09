using System;

namespace RuLaw
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  public interface IQuestionsLawApiCall : IPagedLawApiCall<IQuestionsLawApiCall>
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    IQuestionsLawApiCall From(DateTime date);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    IQuestionsLawApiCall Name(string name);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    IQuestionsLawApiCall To(DateTime date);
  }
}