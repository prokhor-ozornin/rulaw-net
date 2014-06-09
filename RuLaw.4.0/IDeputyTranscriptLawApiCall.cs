using System;

namespace RuLaw
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  public interface IDeputyTranscriptLawApiCall : IPagedLawApiCall<IDeputyTranscriptLawApiCall>
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    IDeputyTranscriptLawApiCall Deputy(long id);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="from"></param>
    /// <returns></returns>
    IDeputyTranscriptLawApiCall From(DateTime from);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    IDeputyTranscriptLawApiCall Name(string name);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="to"></param>
    /// <returns></returns>
    IDeputyTranscriptLawApiCall To(DateTime to);
  }
}