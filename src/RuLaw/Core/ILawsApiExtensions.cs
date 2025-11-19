namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="ILawsApi"/> interface.</para>
/// </summary>
/// <seealso cref="ILawsApi"/>
public static class ILawsApiExtensions
{
  /// <param name="api">API caller instance to be used.</param>
  extension(ILawsApi api)
  {
    /// <summary>
    ///   <para>Returns list of found laws. Response contains records of laws as well as latest events for each of the law.</para>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="api"/> or <paramref name="request"/> is <see langword="null"/>.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-po-zakonoproektam"/>
    public ILawsSearchResult Search(ILawsApiRequest request)
    {
      if (api is null) throw new ArgumentNullException(nameof(api));
      if (request is null) throw new ArgumentNullException(nameof(request));

      return api.SearchAsync(request).Result;
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="api"/> or <paramref name="action"/> is <see langword="null"/>.</exception>
    public ILawsSearchResult Search(Action<ILawsApiRequest> action) => api.SearchAsync(action).Result;

    /// <summary>
    ///   <para>Returns list of found laws. Response contains records of laws as well as latest events for each of the law.</para>
    /// </summary>
    /// <param name="action">Delegate to configure parameters of request.</param>
    /// <param name="cancellation"></param>
    /// <returns>Laws search result.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="api"/> or <paramref name="action"/> is <see langword="null"/>.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-po-zakonoproektam"/>
    public Task<ILawsSearchResult> SearchAsync(Action<ILawsApiRequest> action, CancellationToken cancellation = default)
    {
      if (api is null) throw new ArgumentNullException(nameof(api));
      if (action is null) throw new ArgumentNullException(nameof(action));

      var request = new LawsApiRequest();

      action.Invoke(request);

      return api.SearchAsync(request, cancellation);
    }
  }
}