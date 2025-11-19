namespace RuLaw;

/// <summary>
///   <para>A set of extension methods for the <see cref="IQuestionsApi"/> interface.</para>
/// </summary>
/// <seealso cref="IQuestionsApi"/>
public static class IQuestionsApiExtensions
{
  /// <param name="api"></param>
  extension(IQuestionsApi api)
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    public IQuestionsSearchResult Search(IQuestionsApiRequest request = null) => api?.SearchAsync(request).Result ?? throw new ArgumentNullException(nameof(api));

    /// <summary>
    ///   <para>Returns list of questions of the meetings agenda of the State Duma.</para>
    /// </summary>
    /// <param name="action">Delegate to configure additional parameters of request.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/voprosi-zasedaniy-gosudarstvennoy-dumi"/>
    public IQuestionsSearchResult Search(Action<IQuestionsApiRequest> action = null) => api?.SearchAsync(action).Result ?? throw new ArgumentNullException(nameof(api));

    /// <summary>
    ///   <para>Returns list of questions of the meetings agenda of the State Duma.</para>
    /// </summary>
    /// <param name="action">Delegate to configure additional parameters of request.</param>
    /// <param name="cancellation"></param>
    /// <returns>Questions search result.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="api"/> is <see langword="null"/>.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso href="http://api.duma.gov.ru/pages/dokumentatsiya/voprosi-zasedaniy-gosudarstvennoy-dumi"/>
    public Task<IQuestionsSearchResult> SearchAsync(Action<IQuestionsApiRequest> action = null, CancellationToken cancellation = default)
    {
      if (api is null) throw new ArgumentNullException(nameof(api));

      var request = new QuestionsApiRequest();

      action?.Invoke(request);

      return api.SearchAsync(request, cancellation);
    }
  }
}