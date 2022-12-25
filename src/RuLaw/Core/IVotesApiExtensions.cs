namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IVotesApi"/>.</para>
/// </summary>
/// <seealso cref="IVotesApi"/>
public static class IVotesApiExtensions
{
  /// <summary>
  ///   <para>Returns results of votes search.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Votes search result.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-golosovaniy"/>
  public static Task<IVotesSearchResult> Search(this IVotesApi api, Action<IVotesSearchApiRequest> action, CancellationToken cancellation = default)
  {
    var request = new VotesSearchApiRequest();

    action(request);

    return api.Search(request, cancellation);
  }

  /// <summary>
  ///   <para>Returns results of votes search.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="result">Votes search result.</param>
  /// <param name="request">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns><c>true</c> if call was successful and <paramref name="result"/> output parameter contains result of votes search, or <c>false</c> if call failed and <paramref name="result"/> output parameter is a <c>null</c> reference.</returns>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-golosovaniy"/>
  public static bool Search(this IVotesApi api, out IVotesSearchResult? result, Action<IVotesSearchApiRequest> request, CancellationToken cancellation = default)
  {
    try
    {
      result = api.Search(request, cancellation).Result;
      return true;
    }
    catch
    {
      result = null;
      return true;
    }
  }
}