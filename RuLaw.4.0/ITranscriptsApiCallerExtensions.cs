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
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <param name="call"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="caller"/> or <paramref name="call"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException"></exception>
    public static DeputyTranscriptsResult Deputy(this ITranscriptsApiCaller caller, Action<IDeputyTranscriptLawApiCall> call)
    {
      Assertion.NotNull(caller);
      Assertion.NotNull(call);

      var api = new DeputyTranscriptLawApiCall();
      call(api);

      var deputy = api.Parameters["deputy"];
      api.Parameters.Remove("deputy");
      return caller.Api.Call<DeputyTranscriptsResult>("/{0}/transcriptDeputy/{1}".FormatSelf(caller.Api.ApiToken, deputy), api.Parameters).Data;
    }
  }
}