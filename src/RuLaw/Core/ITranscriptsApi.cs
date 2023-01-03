namespace RuLaw;

/// <summary>
///   <para>Represents an API caller regarding operations of searching for transcripts.</para>
/// </summary>
public interface ITranscriptsApi
{
  /// <summary>
  ///   <para>Returns full transcripts text for given date.</para>
  /// </summary>
  /// <param name="date">Date for which to return transcripts.</param>
  /// <param name="cancellation"></param>
  /// <returns>Transcripts for given date.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-na-zadannuyu-datu"/>
  Task<IDateTranscriptsResult> DateAsync(DateTimeOffset date, CancellationToken cancellation = default);

  /// <summary>
  ///   <para>Returns transcripts of particular deputy's speeches.</para>
  /// </summary>
  /// <param name="request">Parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Transcripts of given deputy.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-vistupleniy-deputata"/>
  Task<IDeputyTranscriptsResult> DeputyAsync(IDeputyTranscriptApiRequest request, CancellationToken cancellation = default);

  /// <summary>
  ///   <para>Returns transcript of given law.</para>
  /// </summary>
  /// <param name="number">Number of law.</param>
  /// <param name="cancellation"></param>
  /// <returns>Transcript of given law.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-po-zakonoproektu"/>
  Task<ILawTranscriptsResult> LawAsync(string number, CancellationToken cancellation = default);

  /// <summary>
  ///   <para>Returns transcripts of Duma's agenda question.</para>
  /// </summary>
  /// <param name="meeting">Meeting's code.</param>
  /// <param name="question">Question's code.</param>
  /// <param name="cancellation"></param>
  /// <returns>Transcript of agenda's question.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/stenogramma-rassmotreniya-voprosa"/>
  Task<IQuestionTranscriptsResult> QuestionAsync(long meeting, long question, CancellationToken cancellation = default);

  /// <summary>
  ///   <para>Returns transcripts of resolution's draft.</para>
  /// </summary>
  /// <param name="number">Number of resolution.</param>
  /// <param name="cancellation"></param>
  /// <returns>Transcript of resolution.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-po-proektu-postanovleniya"/>
  Task<IResolutionTranscriptsResult> ResolutionAsync(string number, CancellationToken cancellation = default);
}