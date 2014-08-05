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
    ///   <para>API token, used to perform web requests. Must be obtained by developers.</para>
    /// </summary>
    string ApiToken { get; }

    /// <summary>
    ///   <para>Application token, used to perform web requests. Must be obtained by developers.</para>
    /// </summary>
    string AppToken { get; }

    /// <summary>
    ///   <para>Data exchange format to use.</para>
    /// </summary>
    ApiDataFormat Format { get; }

    /// <summary>
    ///   <para>Makes a remote call to Russian State Duma REST web service and returns it's response.</para>
    ///   <para>Uses value of <see cref="Format"/> for data exchange.</para>
    /// </summary>
    /// <param name="resource">Relative URL of web resource to be used. Base endpoint URL is predefined by implentation.</param>
    /// <param name="parameters">Map of query parameters names/values.</param>
    /// <param name="headers">Map of HTTP headers names/values.</param>
    /// <returns>Response from REST web service.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="resource"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="resource"/> is <see cref="string.Empty"/> string.</exception>
    /// <exception cref="RuLawException">If error occurs during the processing of web request, or if request was invalid.</exception>
    IRestResponse Call(string resource, IDictionary<string, object> parameters = null, IDictionary<string, object> headers = null);

    /// <summary>
    ///   <para>Makes a remote call to Russian State Duma REST web service and returns deserialized generic response.</para>
    ///   <para>Uses value of <see cref="Format"/> for data exchange.</para>
    /// </summary>
    /// <typeparam name="T">Type of object that is created from web service's response.</typeparam>
    /// <param name="resource">Relative URL of web resource to be used. Base endpoint URL is predefined by implementation.</param>
    /// <param name="parameters">Map of query parameters names/values.</param>
    /// <param name="headers">Map of HTTP headers names/values.</param>
    /// <returns>Generic response from REST web service.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="resource"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="resource"/> is <see cref="string.Empty"/> string.</exception>
    /// <exception cref="RuLawException">If error occurs during the processing of web request, or if request was invalid.</exception>
    IRestResponse<T> Call<T>(string resource, IDictionary<string, object> parameters = null, IDictionary<string, object> headers = null) where T : new();
  }
}