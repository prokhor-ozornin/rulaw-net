namespace RuLaw
{
  using System;
  using System.Globalization;
  using Catharsis.Commons;

  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IVotesApiCaller"/>.</para>
  /// </summary>
  /// <seealso cref="IVotesApiCaller"/>
  public static class IVotesApiCallerExtensions
  {
    /// <summary>
    ///   <para>Returns results of votes search.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <param name="call">Delegate to configure additional parameters of request.</param>
    /// <returns>Votes search result.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="caller"/> or <paramref name="call"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-golosovaniy"/>
    public static IVotesSearchResult Search(this IVotesApiCaller caller, Action<IVotesSearchLawApiCall> call)
    {
      Assertion.NotNull(caller);
      Assertion.NotNull(call);

      var api = new VotesSearchLawApiCall();
      call(api);

      return caller.Api.Call<VotesSearchResult>(string.Format(CultureInfo.InvariantCulture, "/{0}/voteSearch", caller.Api.ApiToken), api.Parameters).Data;
    }

    /// <summary>
    ///   <para>Returns results of votes search.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <param name="call">Delegate to configure additional parameters of request.</param>
    /// <param name="result">Votes search result.</param>
    /// <returns><c>true</c> if call was successful and <paramref name="result"/> output parameter contains result of votes search, or <c>false</c> if call failed and <paramref name="result"/> output parameter is a <c>null</c> reference.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="caller"/> or <paramref name="call"/> is a <c>null</c> reference.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-golosovaniy"/>
    public static bool Search(this IVotesApiCaller caller, Action<IVotesSearchLawApiCall> call, out IVotesSearchResult result)
    {
      Assertion.NotNull(caller);
      Assertion.NotNull(call);

      try
      {
        result = caller.Search(call);
        return true;
      }
      catch
      {
        result = null;
        return true;
      }
    }
  }
}