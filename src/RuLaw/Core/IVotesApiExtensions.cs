namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IVotesApi"/> interface.</para>
/// </summary>
/// <seealso cref="IVotesApi"/>
public static class IVotesApiExtensions
{
  /// <param name="api"></param>
  extension(IVotesApi api)
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="api"/> or <paramref name="request"/> is <see langword="null"/>.</exception>
    public IVotesSearchResult Search(IVotesSearchApiRequest request)
    {
      if (api is null) throw new ArgumentNullException(nameof(api));
      if (request is null) throw new ArgumentNullException(nameof(request));
   
      return api.SearchAsync(request).Result;
    }

    /// <summary>
    ///   <para>Returns results of votes search.</para>
    /// </summary>
    /// <param name="action">Delegate to configure additional parameters of request.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="api"/> or <paramref name="action"/> is <see langword="null"/>.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-golosovaniy"/>
    public IVotesSearchResult Search(Action<IVotesSearchApiRequest> action)
    {
      if (api is null) throw new ArgumentNullException(nameof(api));
      if (action is null) throw new ArgumentNullException(nameof(action));

      return api.SearchAsync(action).Result;
    }

    /// <summary>
    ///   <para>Returns results of votes search.</para>
    /// </summary>
    /// <param name="action">Delegate to configure additional parameters of request.</param>
    /// <param name="cancellation"></param>
    /// <returns>Votes search result.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="api"/> or <paramref name="action"/> is <see langword="null"/>.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-golosovaniy"/>
    public Task<IVotesSearchResult> SearchAsync(Action<IVotesSearchApiRequest> action, CancellationToken cancellation = default)
    {
      if (api is null) throw new ArgumentNullException(nameof(api));
      if (action is null) throw new ArgumentNullException(nameof(action));

      var request = new VotesSearchApiRequest();

      action(request);

      return api.SearchAsync(request, cancellation);
    }
  }
}