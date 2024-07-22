namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IVotesApi"/> interface.</para>
/// </summary>
/// <seealso cref="IVotesApi"/>
public static class IVotesApiExtensions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="api"></param>
  /// <param name="request"></param>
  /// <returns></returns>
  public static IVotesSearchResult Search(this IVotesApi api, IVotesSearchApiRequest request) => api.SearchAsync(request).Result;

  /// <summary>
  ///   <para>Returns results of votes search.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-golosovaniy"/>
  public static IVotesSearchResult Search(this IVotesApi api, Action<IVotesSearchApiRequest> action)
  {
    if (api is null) throw new ArgumentNullException(nameof(api));
    if (action is null) throw new ArgumentNullException(nameof(action));

    return api.SearchAsync(action).Result;
  }

  /// <summary>
  ///   <para>Returns results of votes search.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Votes search result.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-golosovaniy"/>
  public static Task<IVotesSearchResult> SearchAsync(this IVotesApi api, Action<IVotesSearchApiRequest> action, CancellationToken cancellation = default)
  {
    if (api is null) throw new ArgumentNullException(nameof(api));
    if (action is null) throw new ArgumentNullException(nameof(action));

    var request = new VotesSearchApiRequest();

    action(request);

    return api.SearchAsync(request, cancellation);
  }
}