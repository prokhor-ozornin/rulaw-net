using System;

namespace RuLaw
{
  /// <summary>
  ///   <para>Represents an API caller regarding operations of searching for transcripts.</para>
  /// </summary>
  public interface ITranscriptsApiCaller
  {
    /// <summary>
    ///   <para>Russian State Duma REST API caller instance.</para>
    /// </summary>
    IApiCaller Api { get; }

    /// <summary>
    ///   <para>Returns full transcripts text for given date.</para>
    /// </summary>
    /// <param name="date">Date for which to return transcripts.</param>
    /// <returns>Transcripts for given date.</returns>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-na-zadannuyu-datu"/>
    DateTranscriptsResult Date(DateTime date);

    /// <summary>
    ///   <para>Returns transcripts of particular deputy's speeches.</para>
    /// </summary>
    /// <param name="id">Identifier of deputy.</param>
    /// <param name="from">Lower bound (min) date of sessions.</param>
    /// <param name="to">Upper bound (max) date of sessions.</param>
    /// <param name="name">Name of question.</param>
    /// <param name="page">Number of page in paged result. Equals to 1 by default.</param>
    /// <param name="limit">Number of records per page. Equals to 20 by default.</param>
    /// <returns>Transcripts of given deputy.</returns>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-vistupleniy-deputata"/>
    DeputyTranscriptsResult Deputy(long id, DateTime? from = null, DateTime? to = null, string name = null, int? page = null, PageSize? limit = null);

    /// <summary>
    ///   <para>Returns transcript of given law.</para>
    /// </summary>
    /// <param name="number">Number of law.</param>
    /// <returns>Transcript of given law.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="number"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="number"/> is <see cref="string.Empty"/> string.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-po-zakonoproektu"/>
    LawTranscriptsResult Law(string number);

    /// <summary>
    ///   <para>Returns transcripts of Duma's agenda question.</para>
    /// </summary>
    /// <param name="meeting">Meeting's code.</param>
    /// <param name="question">Question's code.</param>
    /// <returns>Transcript of agenda's question.</returns>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/stenogramma-rassmotreniya-voprosa"/>
    QuestionTranscriptsResult Question(int meeting, int question);

    /// <summary>
    ///   <para>Returns transcripts of resolution's draft.</para>
    /// </summary>
    /// <param name="number">Number of resolution.</param>
    /// <returns>Transcript of resolution.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="number"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="number"/> is <see cref="string.Empty"/> string.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-po-proektu-postanovleniya"/>
    ResolutionTranscriptsResult Resolution(string number);
  }
}