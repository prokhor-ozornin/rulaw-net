﻿namespace RuLaw;

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
  /// <param name="request"></param>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-po-zakonoproektam"/>
  public static ILawsSearchResult Search(this ILawsApi api, ILawsApiRequest request) => api.SearchAsync(request).Result;

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="api"></param>
  /// <param name="action"></param>
  /// <returns></returns>
  public static ILawsSearchResult Search(this ILawsApi api, Action<ILawsApiRequest> action) => api.SearchAsync(action).Result;

  /// <summary>
  ///   <para>Returns list of found laws. Response contains records of laws as well as latest events for each of the law.</para>
  /// </summary>
  /// <param name="api">API caller instance to be used.</param>
  /// <param name="action">Delegate to configure parameters of request.</param>
  /// <param name="cancellation"></param>
  /// <returns>Laws search result.</returns>
  /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
  /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-po-zakonoproektam"/>
  public static Task<ILawsSearchResult> SearchAsync(this ILawsApi api, Action<ILawsApiRequest> action, CancellationToken cancellation = default)
  {
    var request = new LawsApiRequest();

    action.Invoke(request);

    return api.SearchAsync(request, cancellation);
  }
}