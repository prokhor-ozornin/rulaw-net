using System;
using System.Collections.Generic;
using Catharsis.Commons;
using RestSharp;

namespace RuLaw
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IApiCallerExtensions"/>.</para>
  /// </summary>
  /// <seealso cref="IApiCaller"/>
  public static class IApiCallerExtensions
  {
    /// <summary>
    ///   <para>Makes a remote call to Russian State Duma REST web service and returns it's response.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <param name="resource">Relative URL of web resource to be used. Base endpoint URL is predefined by implentation.</param>
    /// <param name="parameters">Object whose public properties represent query parameters names/values.</param>
    /// <param name="headers">Object whose public properties represent HTTP headers names/values.</param>
    /// <returns>Response from REST web service.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="caller"/> or <paramref name="resource"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="resource"/> is <see cref="string.Empty"/> string.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    public static IRestResponse Call(this IApiCaller caller, string resource, object parameters = null, object headers = null)
    {
      Assertion.NotNull(caller);
      Assertion.NotEmpty(resource);

      IDictionary<string, object> parametersMap = null;
      if (parameters != null)
      {
        parametersMap = new Dictionary<string, object>();
        foreach (var property in parameters.GetType().GetProperties())
        {
          parametersMap[property.Name] = property.GetValue(parameters, null);
        }
      }

      IDictionary<string, object> headersMap = null;
      if (headers != null)
      {
        headersMap = new Dictionary<string, object>();
        foreach (var property in headers.GetType().GetProperties())
        {
          headersMap[property.Name] = property.GetValue(parameters, null);
        }
      }

      return caller.Call(resource, parametersMap, headersMap);
    }

    /// <summary>
    ///   <para>Makes a remote call to Russian State Duma REST web service and returns deserialized generic response.</para>
    /// </summary>
    /// <typeparam name="T">Type of object that is created from web service's response.</typeparam>
    /// <param name="caller">API caller instance to be used.</param>
    /// <param name="resource">Relative URL of web resource to be used. Base endpoint URL is predefined by implentation.</param>
    /// <param name="parameters">Object whose public properties represent query parameters names/values.</param>
    /// <param name="headers">Object whose public properties represent HTTP headers names/values.</param>
    /// <returns>Generic response from REST web service.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="caller"/> or <paramref name="resource"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="resource"/> is <see cref="string.Empty"/> string.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    public static IRestResponse<T> Call<T>(this IApiCaller caller, string resource, object parameters = null, object headers = null) where T : new()
    {
      Assertion.NotNull(caller);
      Assertion.NotEmpty(resource);

      IDictionary<string, object> parametersMap = null;
      if (parameters != null)
      {
        parametersMap = new Dictionary<string, object>();
        foreach (var property in parameters.GetType().GetProperties())
        {
          parametersMap[property.Name] = property.GetValue(parameters, null);
        }
      }

      IDictionary<string, object> headersMap = null;
      if (headers != null)
      {
        headersMap = new Dictionary<string, object>();
        foreach (var property in parameters.GetType().GetProperties())
        {
          headersMap[property.Name] = property.GetValue(parameters, null);
        }
      }

      return caller.Call<T>(resource, parametersMap, headersMap);
    }

    /// <summary>
    ///   <para>Returns list of laws branches.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <returns>Collection of laws branches.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-otrasley-zakonodatelstva"/>
    public static IList<LawBranch> Branches(this IApiCaller caller)
    {
      Assertion.NotNull(caller);

      return caller.Call<List<LawBranch>>("/{0}/classes".FormatSelf(caller.ApiToken)).Data;
    }

    /// <summary>
    ///   <para>Returns list of committees.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <returns>Collection of committees.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-komitetov"/>
    public static IList<Committee> Committees(this IApiCaller caller)
    {
      Assertion.NotNull(caller);

      return caller.Call<List<Committee>>("/{0}/committees".FormatSelf(caller.ApiToken)).Data;
    }

    /// <summary>
    ///   <para>Returns list of deputies of the State Duma and members of the Federation Council.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <param name="call">Delegate to configure additional parameters of request.</param>
    /// <returns>Collection of deputies.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-deputatov-gd-i-chlenov-sf"/>
    public static IList<Deputy> Deputies(this IApiCaller caller, Action<IDeputiesLawApiCall> call = null)
    {
      Assertion.NotNull(caller);

      IDictionary<string, object> parameters = null;

      if (call != null)
      {
        var api = new DeputiesLawApiCall();
        call(api);
        parameters = api.Parameters;
      }

      return caller.Call<List<Deputy>>("/{0}/deputies".FormatSelf(caller.ApiToken), parameters).Data;
    }

    /// <summary>
    ///   <para>Returns detailed information about specific deputy of the State Duma.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <param name="id">Identifier of deputy.</param>
    /// <returns>Detailed deputy information.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/svedeniya-o-deputate"/>
    public static DeputyInfo Deputy(this IApiCaller caller, long id)
    {
      Assertion.NotNull(caller);

      if (caller.Format == ApiDataFormat.Xml)
      {
        return caller.Call<DeputySearchResult>("/{0}/deputy".FormatSelf(caller.ApiToken), new Dictionary<string, object> { { "id", id } }).Data.Deputy;
      }

      return caller.Call<DeputyInfo>("/{0}/deputy".FormatSelf(caller.ApiToken), new Dictionary<string, object> { { "id", id } }).Data;
    }

    /// <summary>
    ///   <para>Returns list of federal law authorities.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <param name="call">Delegate to configure additional parameters of request.</param>
    /// <returns>Collection of authorities.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-federalnih-organov-vlasti"/>
    public static IList<FederalAuthority> FederalAuthorities(this IApiCaller caller, Action<IAuthoritiesLawApiCall> call = null)
    {
      Assertion.NotNull(caller);

      IDictionary<string, object> parameters = null;

      if (call != null)
      {
        var api = new AuthoritiesLawApiCall();
        call(api);
        parameters = api.Parameters;
      }

      return caller.Call<List<FederalAuthority>>("/{0}/federal-organs".FormatSelf(caller.ApiToken), parameters).Data;
    }

    /// <summary>
    ///   <para>Returns list of instances.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <param name="call">Delegate to configure additional parameters of request.</param>
    /// <returns>Collection of instances.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-instantsiy-rassmotreniya"/>
    public static IList<Instance> Instances(this IApiCaller caller, Action<IInstancesLawApiCall> call = null)
    {
      Assertion.NotNull(caller);

      IDictionary<string, object> parameters = null;

      if (call != null)
      {
        var api = new InstancesLawApiCall();
        call(api);
        parameters = api.Parameters;
      }

      return caller.Call<List<Instance>>("/{0}/instances".FormatSelf(caller.ApiToken), parameters).Data;
    }

    /// <summary>
    ///   <para>Returns list of found laws. Response contains records of laws as well as latest events for each of the law.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <param name="call">Delegate to configure parameters of request.</param>
    /// <returns>Laws search result.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="caller"/> or <paramref name="call"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/poisk-po-zakonoproektam"/>
    public static LawsSearchResult Laws(this IApiCaller caller, Action<ILawsLawApiCall> call)
    {
      Assertion.NotNull(caller);
      Assertion.NotNull(call);

      var api = new LawsLawApiCall();
      call(api);

      return caller.Call<LawsSearchResult>("/{0}/search".FormatSelf(caller.ApiToken), api.Parameters).Data;
    }

    /// <summary>
    ///   <para>Returns list of State Duma's convocations and sessions.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <returns>Collection of convocations.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-sozivov-i-sessiy"/>
    public static IList<Convocation> Convocations(this IApiCaller caller)
    {
      Assertion.NotNull(caller);

      return caller.Call<List<Convocation>>("/{0}/periods".FormatSelf(caller.ApiToken)).Data;
    }

    /// <summary>
    ///   <para>Returns list of questions of the meetings agend of the State Duma.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <param name="call">Delegate to configure additional parameters of request.</param>
    /// <returns>Questions search result.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/voprosi-zasedaniy-gosudarstvennoy-dumi"/>
    public static QuestionsSearchResult Questions(this IApiCaller caller, Action<IQuestionsLawApiCall> call = null)
    {
      Assertion.NotNull(caller);

      IDictionary<string, object> parameters = null;

      if (call != null)
      {
        var api = new QuestionsLawApiCall();
        call(api);
        parameters = api.Parameters;
      }

      return caller.Call<QuestionsSearchResult>("/{0}/questions".FormatSelf(caller.ApiToken), parameters).Data;
    }

    /// <summary>
    ///   <para>Returns list of regional law authorities.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <param name="call">Delegate to configure additional parameters of request.</param>
    /// <returns>Collection of authorities.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-regionalnih-organov-vlasti"/>
    public static IList<RegionalAuthority> RegionalAuthorities(this IApiCaller caller, Action<IAuthoritiesLawApiCall> call = null)
    {
      Assertion.NotNull(caller);

      IDictionary<string, object> parameters = null;

      if (call != null)
      {
        var api = new AuthoritiesLawApiCall();
        call(api);
        parameters = api.Parameters;
      }

      return caller.Call<List<RegionalAuthority>>("/{0}/regional-organs".FormatSelf(caller.ApiToken), parameters).Data;
    }

    /// <summary>
    ///   <para>Returns list of deputies requests.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <returns>Collection of requests.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/deputatskie-zaprosi"/>
    public static IList<DeputyRequest> Requests(this IApiCaller caller)
    {
      Assertion.NotNull(caller);

      return caller.Call<List<DeputyRequest>>("/{0}/requests".FormatSelf(caller.ApiToken)).Data;
    }

    /// <summary>
    ///   <para>Returns list of laws review stages.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <returns>Collection of stages.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-stadiy-rassmotreniya"/>
    public static IList<PhaseStage> Stages(this IApiCaller caller)
    {
      Assertion.NotNull(caller);

      return caller.Call<List<PhaseStage>>("/{0}/stages".FormatSelf(caller.ApiToken)).Data;
    }

    /// <summary>
    ///   <para>Returns list of topics (subject units).</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <returns>Collection of topics.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException">If there was an error during processing of web request, or if request was considered as invalid.</exception>
    /// <seealso cref="http://api.duma.gov.ru/pages/dokumentatsiya/spisok-tematicheskih-blokov"/>
    public static IList<Topic> Topics(this IApiCaller caller)
    {
      Assertion.NotNull(caller);

      return caller.Call<List<Topic>>("/{0}/topics".FormatSelf(caller.ApiToken)).Data;
    }

    /// <summary>
    ///   <para>Returns API caller object to search for transcript.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <returns>Transcripts API caller.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    public static ITranscriptsApiCaller Transcripts(this IApiCaller caller)
    {
      Assertion.NotNull(caller);

      return new TranscriptsApiCaller(caller);
    }

    /// <summary>
    ///   <para>Returns API caller object to search for votes/votings.</para>
    /// </summary>
    /// <param name="caller">API caller instance to be used.</param>
    /// <returns>Votes API caller.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    public static IVotesApiCaller Votes(this IApiCaller caller)
    {
      Assertion.NotNull(caller);

      return new VotesApiCaller(caller);
    }
  }
}