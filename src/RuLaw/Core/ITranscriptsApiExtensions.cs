using Catharsis.Extensions;

namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="ITranscriptsApi"/> interface.</para>
/// </summary>
/// <seealso cref="ITranscriptsApi"/>
public static class ITranscriptsApiExtensions
{
  /// <param name="api"></param>
  extension(ITranscriptsApi api)
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    public IDateTranscriptsResult Date(DateTimeOffset date) => api?.DateAsync(date).Result ?? throw new ArgumentNullException(nameof(api));

    /// <summary>
    ///   <para>Returns transcription of deputy's speeches.</para>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="api"/> or <paramref name="request"/> is <see langword="null"/>.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-vistupleniy-deputata"/>
    public IDeputyTranscriptsResult Deputy(IDeputyTranscriptApiRequest request)
    {
      if (api is null) throw new ArgumentNullException(nameof(api));
      if (request is null) throw new ArgumentNullException(nameof(request));

      return api.DeputyAsync(request).Result;
    }

    /// <summary>
    ///   <para>Returns transcription of deputy's speeches.</para>
    /// </summary>
    /// <param name="action">Delegate to configure additional parameters of request.</param>
    /// <returns>Deputy's transcripts result.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="api"/> or <paramref name="action"/> is <see langword="null"/>.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-vistupleniy-deputata"/>
    public IDeputyTranscriptsResult Deputy(Action<IDeputyTranscriptApiRequest> action)
    {
      if (api is null) throw new ArgumentNullException(nameof(api));
      if (action is null) throw new ArgumentNullException(nameof(action));

      return api.DeputyAsync(action).Result;
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="action"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="api"/> or <paramref name="action"/> is <see langword="null"/>.</exception>
    public async Task<IDeputyTranscriptsResult> DeputyAsync(Action<IDeputyTranscriptApiRequest> action, CancellationToken cancellation = default)
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
    /// <param name="number"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="api"/> or <paramref name="number"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">If <paramref name="number"/> is invalid string.</exception>
    public ILawTranscriptsResult Law(string number)
    {
      if (api is null) throw new ArgumentNullException(nameof(api));
      if (number is null) throw new ArgumentNullException(nameof(number));
      if (number.IsEmpty()) throw new ArgumentException(nameof(number));

      return api.LawAsync(number).Result;
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="meeting"></param>
    /// <param name="question"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    public IQuestionTranscriptsResult Question(long meeting, long question) => api?.QuestionAsync(meeting, question).Result ?? throw new ArgumentNullException(nameof(api));

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="api"/> or <paramref name="number"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">If <paramref name="number"/> is invalid string.</exception>
    public IResolutionTranscriptsResult Resolution(string number)
    {
      if (api is null) throw new ArgumentNullException(nameof(api));
      if (number is null) throw new ArgumentNullException(nameof(number));
      if (number.IsEmpty()) throw new ArgumentException(nameof(number));

      return api.ResolutionAsync(number).Result;
    }
  }
}