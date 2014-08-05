using System;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="ITranscriptsApiCaller"/>.</para>
  /// </summary>
  /// <seealso cref="ITranscriptsApiCaller"/>
  public static class ITranscriptsApiCallerExtensions
  {
    /// <summary>
    ///   <para>Returns transcription of deputy's speeches.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <param name="call">Delegate to configure additional parameters of request.</param>
    /// <returns>Deputy's transcripts result.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="caller"/> or <paramref name="call"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-vistupleniy-deputata"/>
    public static IDeputyTranscriptsResult Deputy(this ITranscriptsApiCaller caller, Action<IDeputyTranscriptLawApiCall> call)
    {
      Assertion.NotNull(caller);
      Assertion.NotNull(call);

      var api = new DeputyTranscriptLawApiCall();
      call(api);

      var deputy = api.Parameters["deputy"];
      api.Parameters.Remove("deputy");
      return caller.Api.Call<DeputyTranscriptsResult>("/{0}/transcriptDeputy/{1}".FormatSelf(caller.Api.ApiToken, deputy), api.Parameters).Data;
    }

    /// <summary>
    ///   <para>Returns transcription of deputy's speeches.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <param name="call">Delegate to configure additional parameters of request.</param>
    /// <param name="result">Deputy's transcripts result.</param>
    /// <returns><c>true</c> if call was successful and <paramref name="result"/> output parameter contains result of deputy's transcripts search, or <c>false</c> if call failed and <paramref name="result"/> output parameter is a <c>null</c> reference.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="caller"/> or <paramref name="call"/> is a <c>null</c> reference.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/stenogrammi-vistupleniy-deputata"/>
    public static bool Deputy(this ITranscriptsApiCaller caller, Action<IDeputyTranscriptLawApiCall> call, out IDeputyTranscriptsResult result)
    {
      Assertion.NotNull(caller);
      Assertion.NotNull(call);

      try
      {
        result = caller.Deputy(call);
        return true;
      }
      catch
      {
        result = null;
        return false;
      }
    }
  }
}