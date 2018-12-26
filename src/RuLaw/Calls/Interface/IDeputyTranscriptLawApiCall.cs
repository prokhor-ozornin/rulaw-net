namespace RuLaw
{
  using System;

  /// <summary>
  ///   <para>Representation of deputies transcripts search request to Russian State Duma REST API.</para>
  /// </summary>
  public interface IDeputyTranscriptLawApiCall : IPagedLawApiCall<IDeputyTranscriptLawApiCall>, ILawApiCall
  {
    /// <summary>
    ///   <para>Specifies identier of deputy, transcripts of whose speeches should be looked up.</para>
    /// </summary>
    /// <param name="id">Identifier of deputy.</param>
    /// <returns>Back reference to the current request.</returns>
    IDeputyTranscriptLawApiCall Deputy(long id);

    /// <summary>
    ///   <para>Specifies lower bound of session's date.</para>
    /// </summary>
    /// <param name="from">Session's date.</param>
    /// <returns>Back reference to the current request.</returns>
    IDeputyTranscriptLawApiCall From(DateTime from);

    /// <summary>
    ///   <para>Specifies name of question.</para>
    /// </summary>
    /// <param name="name">Name of question.</param>
    /// <returns>Back reference to the current request.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    IDeputyTranscriptLawApiCall Name(string name);

    /// <summary>
    ///   <para>Specifies upper bound of session's date.</para>
    /// </summary>
    /// <param name="to">Session's date.</param>
    /// <returns>Back reference to the current request.</returns>
    IDeputyTranscriptLawApiCall To(DateTime to);
  }
}