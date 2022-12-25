namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="ITranscriptsApi"/>.</para>
/// </summary>
/// <seealso cref="ITranscriptsApi"/>
public static class ITranscriptsApiExtensions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="api"></param>
  /// <param name="result"></param>
  /// <param name="date"></param>
  /// <param name="cancellation"></param>
  /// <returns></returns>
  public static bool Date(this ITranscriptsApi api, out IDateTranscriptsResult? result, DateTimeOffset date, CancellationToken cancellation = default)
  {
    try
    {
      result = api.Date(date, cancellation).Result;
      return true;
    }
    catch
    {
      result = null;
      return false;
    }
  }

  /// <summary>
  ///   <para>Returns transcription of deputy's speeches.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Deputy's transcripts result.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-vistupleniy-deputata"/>
  public static Task<IDeputyTranscriptsResult> Deputy(this ITranscriptsApi api, Action<IDeputyTranscriptApiRequest> action, CancellationToken cancellation = default)
  {
    var request = new DeputyTranscriptApiRequest();
    
    action(request);

    return api.Deputy(request, cancellation);
  }

  /// <summary>
  ///   <para>Returns transcription of deputy's speeches.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="result">Deputy's transcripts result.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns><c>true</c> if call was successful and <paramref name="result"/> output parameter contains result of deputy's transcripts search, or <c>false</c> if call failed and <paramref name="result"/> output parameter is a <c>null</c> reference.</returns>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-vistupleniy-deputata"/>
  public static bool Deputy(this ITranscriptsApi api, out IDeputyTranscriptsResult? result, Action<IDeputyTranscriptApiRequest> action, CancellationToken cancellation = default)
  {
    try
    {
      result = api.Deputy(action, cancellation).Result;
      return true;
    }
    catch
    {
      result = null;

      return false;
    }
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="api"></param>
  /// <param name="result"></param>
  /// <param name="number"></param>
  /// <param name="cancellation"></param>
  /// <returns></returns>
  public static bool Law(this ITranscriptsApi api, out ILawTranscriptsResult? result, string number, CancellationToken cancellation = default)
  {
    try
    {
      result = api.Law(number, cancellation).Result;
      return true;
    }
    catch
    {
      result = null;
      return false;
    }
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="api"></param>
  /// <param name="result"></param>
  /// <param name="meeting"></param>
  /// <param name="question"></param>
  /// <param name="cancellation"></param>
  /// <returns></returns>
  public static bool Question(this ITranscriptsApi api, out IQuestionTranscriptsResult? result, long meeting, long question, CancellationToken cancellation = default)
  {
    try
    {
      result = api.Question(meeting, question, cancellation).Result;
      return true;
    }
    catch
    {
      result = null;
      return false;
    }
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="api"></param>
  /// <param name="result"></param>
  /// <param name="number"></param>
  /// <param name="cancellation"></param>
  /// <returns></returns>
  public static bool Resolution(this ITranscriptsApi api, out IResolutionTranscriptsResult? result, string number, CancellationToken cancellation = default)
  {
    try
    {
      result = api.Resolution(number, cancellation).Result;
      return true;
    }
    catch
    {
      result = null;
      return false;
    }
  }
}