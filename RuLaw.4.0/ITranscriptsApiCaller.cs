using System;
using System.Collections.Generic;

namespace RuLaw
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  public interface ITranscriptsApiCaller
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    IApiCaller Api { get; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    /// <exception cref="RuLawException"></exception>
    DateTranscriptsResult Date(DateTime date);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="name"></param>
    /// <param name="page"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    /// <exception cref="RuLawException"></exception>
    DeputyTranscriptsResult Deputy(long id, DateTime? from = null, DateTime? to = null, string name = null, int? page = null, PageSize? limit = null);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="number"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="number"/> is <see cref="string.Empty"/> string.</exception>
    /// <exception cref="RuLawException"></exception>
    LawTranscriptsResult Law(string number);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="meeting"></param>
    /// <param name="question"></param>
    /// <returns></returns>
    /// <exception cref="RuLawException"></exception>
    QuestionTranscriptsResult Question(int meeting, int question);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="number"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="number"/> is <see cref="string.Empty"/> string.</exception>
    /// <exception cref="RuLawException"></exception>
    ResolutionTranscriptsResult Resolution(string number);
  }
}