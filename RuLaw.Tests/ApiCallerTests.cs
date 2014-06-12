using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using Catharsis.Commons;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ApiCaller"/>.</para>
  /// </summary>
  public sealed class ApiCallerTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="ApiCaller(ApiDataFormat, string, string)"/>
    [Fact]
    public void Constructors()
    {
      Assert.Throws<ArgumentNullException>(() => new ApiCaller(ApiDataFormat.Xml, null));
      Assert.Throws<ArgumentException>(() => new ApiCaller(ApiDataFormat.Xml, string.Empty));

      var caller = new ApiCaller(ApiDataFormat.Xml, "apiToken", "appToken");
      Assert.Equal("apiToken", caller.ApiToken);
      Assert.Equal("appToken", caller.AppToken);
      Assert.Equal(ApiDataFormat.Xml, caller.Format);
      Assert.True(caller.Field("jsonSerializer").To<ISerializer>() is RuLawJsonSerializer);
      Assert.True(caller.Field("jsonDeserializer").To<IDeserializer>() is RuLawJsonDeserializer);
      Assert.True(caller.Field("xmlSerializer").To<ISerializer>() is RuLawXmlSerializer);
      Assert.True(caller.Field("xmlDeserializer").To<IDeserializer>() is RuLawXmlDeserializer);

      var client = caller.Field("restClient").To<RestClient>();
      Assert.Equal("http://api.duma.gov.ru/api", client.BaseUrl);
      var token = client.DefaultParameters.FirstOrDefault(x => x.Name == "app_token");
      Assert.NotNull(token);
      Assert.Equal("appToken", token.Value);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ApiCaller.Call(string, IDictionary{string, object}, IDictionary{string, object})"/> method.</description></item>
    ///     <item><description><see cref="ApiCaller.Call{T}(string, IDictionary{string, object}, IDictionary{string, object})"/> method.</description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Call_Methods()
    {
      var caller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).Format(ApiDataFormat.Json));
      try
      {
        caller.Call("/{0}/deputy".FormatSelf(caller.ApiToken));
        throw new InvalidOperationException();
      }
      catch (RuLawException exception)
      {
        Assert.Equal("App token is invalid.", exception.Message);
      }

      caller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]).Format(ApiDataFormat.Json));
      Assert.Throws<ArgumentNullException>(() => caller.Call(null));
      Assert.Throws<ArgumentException>(() => caller.Call(string.Empty));
      Assert.Throws<RuLawException>(() => caller.Call("invalid"));
      Assert.Equal("null", caller.Call("/{0}/deputy".FormatSelf(caller.ApiToken)).Content);

      const long deputyId = 99100142;

      var response = caller.Call("/{0}/deputy".FormatSelf(caller.ApiToken, deputyId), new { Id = deputyId });
      Assert.False(response.Content.IsEmpty());
      Assert.Equal("application/json", response.ContentType);
      Assert.Null(response.ErrorException);
      Assert.Null(response.ErrorMessage);
      Assert.True(response.Cookies.Count > 0);
      Assert.True(response.Headers.Count > 0);
      Assert.Equal("http://api.duma.gov.ru/api/{0}/deputy.json?Id={2}&app_token={1}".FormatSelf(caller.ApiToken, caller.AppToken, deputyId), response.ResponseUri.ToString());
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      Assert.Equal("OK", response.StatusDescription);

      caller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]).Format(ApiDataFormat.Xml));
      response = caller.Call("/{0}/deputy".FormatSelf(caller.ApiToken, deputyId), new { Id = deputyId });
      Assert.False(response.Content.IsEmpty());
      Assert.Equal("text/xml; charset=utf-8", response.ContentType);
      Assert.Null(response.ErrorException);
      Assert.Null(response.ErrorMessage);
      Assert.True(response.Cookies.Count > 0);
      Assert.True(response.Headers.Count > 0);
      Assert.Equal("http://api.duma.gov.ru/api/{0}/deputy.xml?Id={2}&app_token={1}".FormatSelf(caller.ApiToken, caller.AppToken, deputyId), response.ResponseUri.ToString());
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      Assert.Equal("OK", response.StatusDescription);

      caller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).Format(ApiDataFormat.Json));
      try
      {
        caller.Call<DeputyInfo>("/{0}/deputy".FormatSelf(caller.ApiToken));
        throw new InvalidOperationException();
      }
      catch (RuLawException exception)
      {
        Assert.Equal("App token is invalid.", exception.Message);
      }

      caller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]).Format(ApiDataFormat.Json));
      Assert.Throws<ArgumentNullException>(() => caller.Call<DeputyInfo>(null));
      Assert.Throws<ArgumentException>(() => caller.Call<DeputyInfo>(string.Empty));
      Assert.Throws<RuLawException>(() => caller.Call<DeputyInfo>("invalid"));
      Assert.Equal("null", caller.Call<DeputyInfo>("/{0}/deputy".FormatSelf(caller.ApiToken)).Content);

      response = caller.Call<DeputyInfo>("/{0}/deputy".FormatSelf(caller.ApiToken, deputyId), new { Id = deputyId });
      Assert.False(response.Content.IsEmpty());
      Assert.Equal("application/json", response.ContentType);
      Assert.Null(response.ErrorException);
      Assert.Null(response.ErrorMessage);
      Assert.True(response.Cookies.Count > 0);
      Assert.True(response.Headers.Count > 0);
      Assert.Equal("http://api.duma.gov.ru/api/{0}/deputy.json?Id={2}&app_token={1}".FormatSelf(caller.ApiToken, caller.AppToken, deputyId), response.ResponseUri.ToString());
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      Assert.Equal("OK", response.StatusDescription);

      caller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]).Format(ApiDataFormat.Xml));
      response = caller.Call<DeputyInfo>("/{0}/deputy".FormatSelf(caller.ApiToken, deputyId), new { Id = deputyId });
      Assert.False(response.Content.IsEmpty());
      Assert.Equal("text/xml; charset=utf-8", response.ContentType);
      Assert.Null(response.ErrorException);
      Assert.Null(response.ErrorMessage);
      Assert.True(response.Cookies.Count > 0);
      Assert.True(response.Headers.Count > 0);
      Assert.Equal("http://api.duma.gov.ru/api/{0}/deputy.xml?Id={2}&app_token={1}".FormatSelf(caller.ApiToken, caller.AppToken, deputyId), response.ResponseUri.ToString());
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      Assert.Equal("OK", response.StatusDescription);
    }
  }
}