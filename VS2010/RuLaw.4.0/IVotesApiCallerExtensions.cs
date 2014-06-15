using System;
using Catharsis.Commons;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IVotesApiCaller"/>.</para>
  /// </summary>
  /// <seealso cref="IVotesApiCaller"/>
  public static class IVotesApiCallerExtensions
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <param name="call"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="caller"/> or <paramref name="call"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException"></exception>
    public static VotesSearchResult Search(this IVotesApiCaller caller, Action<IVotesSearchLawApiCall> call)
    {
      Assertion.NotNull(caller);
      Assertion.NotNull(call);

      var api = new VotesSearchLawApiCall();
      call(api);

      return caller.Api.Call<VotesSearchResult>("/{0}/voteSearch".FormatSelf(caller.Api.ApiToken), api.Parameters).Data;
    }
  }
}