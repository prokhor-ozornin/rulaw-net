namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IQuestionsApi"/>.</para>
/// </summary>
/// <seealso cref="IQuestionsApi"/>
public static class IQuestionsApiExtensions
{
  /// <summary>
  ///   <para>Returns list of questions of the meetings agenda of the State Duma.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Questions search result.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/voprosi-zasedaniy-gosudarstvennoy-dumi"/>
  public static Task<IQuestionsSearchResult> Search(this IQuestionsApi api, Action<IQuestionsApiRequest>? action = null, CancellationToken cancellation = default)
  {
    var request = new QuestionsApiRequest();

    action?.Invoke(request);

    return api.Search(request, cancellation);
  }

  /// <summary>
  ///   <para>Returns list of questions of the meetings agenda of the State Duma.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="result">Questions search result.</param>
  /// <param name="action">Delegate to configure additional parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns><c>true</c> if call was successful and <paramref name="result"/> output parameter contains questions search result, or <c>false</c> if call failed and <paramref name="result"/> output parameter is a <c>null</c> reference.</returns>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/voprosi-zasedaniy-gosudarstvennoy-dumi"/>
  public static bool Search(this IQuestionsApi api, out IQuestionsSearchResult? result, Action<IQuestionsApiRequest>? action = null, CancellationToken cancellation = default)
  {
    try
    {
      result = api.Search(action, cancellation).Result;
      return true;
    }
    catch
    {
      result = null;
      return false;
    }
  }
}