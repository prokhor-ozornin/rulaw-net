using Catharsis.Extensions;

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
  /// <param name="date"></param>
  /// <returns></returns>
  public static IDateTranscriptsResult Date(this ITranscriptsApi api, DateTimeOffset date) => api is not null ? api.DateAsync(date).Result : throw new ArgumentNullException(nameof(api));

  /// <summary>
  ///   <para>Returns transcription of deputy's speeches.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="request"></param>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-vistupleniy-deputata"/>
  public static IDeputyTranscriptsResult Deputy(this ITranscriptsApi api, IDeputyTranscriptApiRequest request)
  {
    if (api is null) throw new ArgumentNullException(nameof(api));
    if (request is null) throw new ArgumentNullException(nameof(request));

    return api.DeputyAsync(request).Result;
  }

  /// <summary>
  ///   <para>Returns transcription of deputy's speeches.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <returns>Deputy's transcripts result.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-vistupleniy-deputata"/>
  public static IDeputyTranscriptsResult Deputy(this ITranscriptsApi api, Action<IDeputyTranscriptApiRequest> action)
  {
    if (api is null) throw new ArgumentNullException(nameof(api));
    if (action is null) throw new ArgumentNullException(nameof(action));

    return api.DeputyAsync(action).Result;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="api"></param>
  /// <param name="action"></param>
  /// <param name="cancellation"></param>
  /// <returns></returns>
  public static async Task<IDeputyTranscriptsResult> DeputyAsync(this ITranscriptsApi api, Action<IDeputyTranscriptApiRequest> action, CancellationToken cancellation = default)
  {
    if (api is null) throw new ArgumentNullException(nameof(api));
    if (action is null) throw new ArgumentNullException(nameof(action));

    var request = new DeputyTranscriptApiRequest();

    action.Invoke(request);

    return await api.DeputyAsync(request, cancellation);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="api"></param>
  /// <param name="number"></param>
  /// <returns></returns>
  public static ILawTranscriptsResult Law(this ITranscriptsApi api, string number)
  {
    if (api is null) throw new ArgumentNullException(nameof(api));
    if (number is null) throw new ArgumentNullException(nameof(number));
    if (number.IsEmpty()) throw new ArgumentException(nameof(number));

    return api.LawAsync(number).Result;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="api"></param>
  /// <param name="meeting"></param>
  /// <param name="question"></param>
  /// <returns></returns>
  public static IQuestionTranscriptsResult Question(this ITranscriptsApi api, long meeting, long question) => api is not null ? api.QuestionAsync(meeting, question).Result : throw new ArgumentNullException(nameof(api));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="api"></param>
  /// <param name="number"></param>
  /// <returns></returns>
  public static IResolutionTranscriptsResult Resolution(this ITranscriptsApi api, string number)
  {
    if (api is null) throw new ArgumentNullException(nameof(api));
    if (number is null) throw new ArgumentNullException(nameof(number));
    if (number.IsEmpty()) throw new ArgumentException(nameof(number));

    return api.ResolutionAsync(number).Result;
  }
}