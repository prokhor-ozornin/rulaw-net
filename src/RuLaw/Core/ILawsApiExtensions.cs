namespace RuLaw;

/// <summary>
///   <para>Set of extension methods for interface <see cref="ILawsApi"/>.</para>
/// </summary>
/// <seealso cref="ILawsApi"/>
public static class ILawsApiExtensions
{
  /// <summary>
  ///   <para>Returns list of found laws. Response contains records of laws as well as latest events for each of the law.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Laws search result.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-po-zakonoproektam"/>
  public static Task<ILawsSearchResult> Search(this ILawsApi api, Action<ILawsApiRequest> action, CancellationToken cancellation = default)
  {
    var request = new LawsApiRequest();

    action.Invoke(request);

    return api.Search(request, cancellation);
  }

  /// <summary>
  ///   <para>Returns list of found laws. Response contains records of laws as well as latest events for each of the law.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="result">Laws search result.</param>
  /// <param name="action">Delegate to configure parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns><c>true</c> if call was successful and <paramref name="result"/> output parameter contains result of laws search, or <c>false</c> if call failed and <paramref name="result"/> output parameter is a <c>null</c> reference.</returns>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-po-zakonoproektam"/>
  public static bool Search(this ILawsApi api, out ILawsSearchResult? result, Action<ILawsApiRequest> action, CancellationToken cancellation = default)
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