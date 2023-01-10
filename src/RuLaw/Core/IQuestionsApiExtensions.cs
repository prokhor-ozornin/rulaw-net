namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IQuestionsApi"/>.</para>
/// </summary>
/// <seealso cref="IQuestionsApi"/>
public static class IQuestionsApiExtensions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="api"></param>
  /// <param name="request"></param>
  /// <returns></returns>
  public static IQuestionsSearchResult Search(this IQuestionsApi api, IQuestionsApiRequest request = null) => api is not null ? api.SearchAsync(request).Result : throw new ArgumentNullException(nameof(api));

  /// <summary>
  ///   <para>Returns list of questions of the meetings agenda of the State Duma.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/voprosi-zasedaniy-gosudarstvennoy-dumi"/>
  public static IQuestionsSearchResult Search(this IQuestionsApi api, Action<IQuestionsApiRequest> action = null) => api is not null ? api.SearchAsync(action).Result : throw new ArgumentNullException(nameof(api));

  /// <summary>
  ///   <para>Returns list of questions of the meetings agenda of the State Duma.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Questions search result.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/voprosi-zasedaniy-gosudarstvennoy-dumi"/>
  public static Task<IQuestionsSearchResult> SearchAsync(this IQuestionsApi api, Action<IQuestionsApiRequest> action = null, CancellationToken cancellation = default)
  {
    if (api is null) throw new ArgumentNullException(nameof(api));

    var request = new QuestionsApiRequest();

    action?.Invoke(request);

    return api.SearchAsync(request, cancellation);
  }
}