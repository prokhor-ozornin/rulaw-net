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
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <param name="resource"></param>
    /// <param name="parameters"></param>
    /// <param name="headers"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="caller"/> or <paramref name="resource"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="resource"/> is <see cref="string.Empty"/> string.</exception>
    /// <exception cref="RuLawException"></exception>
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
    ///   <para></para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="caller"></param>
    /// <param name="resource"></param>
    /// <param name="parameters"></param>
    /// <param name="headers"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="caller"/> or <paramref name="resource"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="resource"/> is <see cref="string.Empty"/> string.</exception>
    /// <exception cref="RuLawException"></exception>
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
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException"></exception>
    public static IEnumerable<LawBranch> Branches(this IApiCaller caller)
    {
      Assertion.NotNull(caller);

      return caller.Call<List<LawBranch>>("/{0}/classes".FormatSelf(caller.ApiToken)).Data;
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException"></exception>
    public static IEnumerable<Committee> Committees(this IApiCaller caller)
    {
      Assertion.NotNull(caller);

      return caller.Call<List<Committee>>("/{0}/committees".FormatSelf(caller.ApiToken)).Data;
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <param name="call"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException"></exception>
    public static IEnumerable<Deputy> Deputies(this IApiCaller caller, Action<IDeputiesLawApiCall> call = null)
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
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException"></exception>
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
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <param name="call"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException"></exception>
    public static IEnumerable<FederalAuthority> FederalAuthorities(this IApiCaller caller, Action<IAuthoritiesLawApiCall> call = null)
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
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <param name="call"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException"></exception>
    public static IEnumerable<Instance> Instances(this IApiCaller caller, Action<IInstancesLawApiCall> call = null)
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
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <param name="call"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="caller"/> or <paramref name="call"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException"></exception>
    public static LawsSearchResult Laws(this IApiCaller caller, Action<ILawsLawApiCall> call)
    {
      Assertion.NotNull(caller);
      Assertion.NotNull(call);

      var api = new LawsLawApiCall();
      call(api);

      return caller.Call<LawsSearchResult>("/{0}/search".FormatSelf(caller.ApiToken), api.Parameters).Data;
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException"></exception>
    public static IEnumerable<Convocation> Convocations(this IApiCaller caller)
    {
      Assertion.NotNull(caller);

      return caller.Call<List<Convocation>>("/{0}/periods".FormatSelf(caller.ApiToken)).Data;
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <param name="call"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException"></exception>
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
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <param name="call"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException"></exception>
    public static IEnumerable<RegionalAuthority> RegionalAuthorities(this IApiCaller caller, Action<IAuthoritiesLawApiCall> call = null)
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
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException"></exception>
    public static IEnumerable<DeputyRequest> Requests(this IApiCaller caller)
    {
      Assertion.NotNull(caller);

      return caller.Call<List<DeputyRequest>>("/{0}/requests".FormatSelf(caller.ApiToken)).Data;
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException"></exception>
    public static IEnumerable<PhaseStage> Stages(this IApiCaller caller)
    {
      Assertion.NotNull(caller);

      return caller.Call<List<PhaseStage>>("/{0}/stages".FormatSelf(caller.ApiToken)).Data;
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    /// <exception cref="RuLawException"></exception>
    public static IEnumerable<Topic> Topics(this IApiCaller caller)
    {
      Assertion.NotNull(caller);

      return caller.Call<List<Topic>>("/{0}/topics".FormatSelf(caller.ApiToken)).Data;
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    public static ITranscriptsApiCaller Transcripts(this IApiCaller caller)
    {
      Assertion.NotNull(caller);

      return new TranscriptsApiCaller(caller);
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="caller"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="caller"/> is a <c>null</c> reference.</exception>
    public static IVotesApiCaller Votes(this IApiCaller caller)
    {
      Assertion.NotNull(caller);

      return new VotesApiCaller(caller);
    }
  }
}