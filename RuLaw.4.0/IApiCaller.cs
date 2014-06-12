using System;
using System.Collections.Generic;
using RestSharp;

namespace RuLaw
{
  /// <summary>
  ///   <para>Entry point for RuLaw API.</para>
  /// </summary>
  public interface IApiCaller
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    string ApiToken { get; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    string AppToken { get; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    ApiDataFormat Format { get; }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="resource"></param>
    /// <param name="parameters"></param>
    /// <param name="headers"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="resource"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="resource"/> is <see cref="string.Empty"/> string.</exception>
    /// <exception cref="RuLawException"></exception>
    IRestResponse Call(string resource, IDictionary<string, object> parameters = null, IDictionary<string, object> headers = null);

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="resource"></param>
    /// <param name="parameters"></param>
    /// <param name="headers"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="resource"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="resource"/> is <see cref="string.Empty"/> string.</exception>
    /// <exception cref="RuLawException"></exception>
    IRestResponse<T> Call<T>(string resource, IDictionary<string, object> parameters = null, IDictionary<string, object> headers = null) where T : new();
  }
}