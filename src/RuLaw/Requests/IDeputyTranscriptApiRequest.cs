namespace RuLaw;

/// <summary>
///   <para>Representation of deputies transcripts search request to Russian State Duma REST API.</para>
/// </summary>
public interface IDeputyTranscriptApiRequest : IPagedApiRequest<IDeputyTranscriptApiRequest>, IApiRequest
{
  /// <summary>
  ///   <para>Specifies name of question.</para>
  /// </summary>
  /// <param name="name">Name of question.</param>
  /// <returns>Back reference to the current request.</returns>
  IDeputyTranscriptApiRequest Name(string? name);

  /// <summary>
  ///   <para>Specifies identifier of deputy, transcripts of whose speeches should be looked up.</para>
  /// </summary>
  /// <param name="id">Identifier of deputy.</param>
  /// <returns>Back reference to the current request.</returns>
  IDeputyTranscriptApiRequest Deputy(long? id);

  /// <summary>
  ///   <para>Specifies lower bound of session's date.</para>
  /// </summary>
  /// <param name="from">Session's date.</param>
  /// <returns>Back reference to the current request.</returns>
  IDeputyTranscriptApiRequest FromDate(DateTimeOffset? from);

  /// <summary>
  ///   <para>Specifies upper bound of session's date.</para>
  /// </summary>
  /// <param name="to">Session's date.</param>
  /// <returns>Back reference to the current request.</returns>
  IDeputyTranscriptApiRequest ToDate(DateTimeOffset? to);
}