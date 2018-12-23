using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using Catharsis.Commons;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace RuLaw
{
    using System.Globalization;

    internal sealed class ApiCaller : IApiCaller
  {
    private const string EndpointUrl = "http://api.duma.gov.ru/api";

    private readonly string apiToken;
    private readonly string appToken;
    private readonly ApiDataFormat format;
    private readonly RestClient restClient;
    private readonly ISerializer jsonSerializer = new RuLawJsonSerializer();
    private readonly IDeserializer jsonDeserializer = new RuLawJsonDeserializer();
    private readonly IXmlSerializer xmlSerializer = new RuLawXmlSerializer();
    private readonly IDeserializer xmlDeserializer = new RuLawXmlDeserializer();
    
    public ApiCaller(ApiDataFormat format, string apiToken, string appToken = null)
    {
      Assertion.NotEmpty(apiToken);

      this.apiToken = apiToken;
      this.appToken = appToken;
      this.format = format;

      this.restClient = new RestClient(string.Format(CultureInfo.InvariantCulture, EndpointUrl, apiToken));
      this.restClient.AddHandler("application/xml", this.xmlDeserializer);
      this.restClient.AddHandler("text/xml", this.xmlDeserializer);
      this.restClient.AddHandler("application/json", this.jsonDeserializer);
      this.restClient.AddHandler("text/json", this.jsonDeserializer);
      this.restClient.AddHandler("text/x-json", this.jsonDeserializer);
      this.restClient.AddHandler("text/javascript", this.jsonDeserializer);
      this.restClient.AddHandler("*", this.xmlDeserializer);
      if (!appToken.IsEmpty())
      {
        this.restClient.AddDefaultParameter("app_token", appToken);
      }
    }

    public string ApiToken
    {
      get { return this.apiToken; }
    }

    public string AppToken
    {
      get { return this.appToken; }
    }

    public ApiDataFormat Format
    {
      get { return this.format; }
    }

    public IRestResponse Call(string resource, IDictionary<string, object> parameters = null, IDictionary<string, object> headers = null)
    {
      Assertion.NotEmpty(resource);

      var request = this.CreateRequest(resource, parameters);
      var response = this.restClient.Get(request);

      if (response.ErrorException != null || response.StatusCode != HttpStatusCode.OK)
      {
        throw new RuLawException(new Error((int) response.StatusCode, response.ErrorMessage ?? response.StatusDescription), response.ErrorException);
      }

      Error error = null;
      try
      {
        switch (request.RequestFormat)
        {
          case DataFormat.Json:
            error = response.Content.Json<Error>();
            break;

          case DataFormat.Xml:
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Error), new XmlRootAttribute("result"));
            using (var source = new StringReader(response.Content))
            {
              error = serializer.Deserialize(source).To<Error>();
            }
            break;
        }
      }
      catch
      {
      }
      if (error != null && !error.Text.IsEmpty())
      {
        throw new RuLawException(error);
      }

      return response;
    }

    public IRestResponse<T> Call<T>(string resource, IDictionary<string, object> parameters = null, IDictionary<string, object> headers = null) where T : new()
    {
      var request = this.CreateRequest(resource, parameters);
      var response = this.restClient.Get<T>(request);

      if (response.ErrorException != null || response.StatusCode != HttpStatusCode.OK)
      {
        throw new RuLawException(new Error((int) response.StatusCode, response.ErrorMessage ?? response.StatusDescription), response.ErrorException);
      }

      Error error = null;
      try
      {
        switch (request.RequestFormat)
        {
          case DataFormat.Json:
            error = response.Content.Json<Error>();
            break;

          case DataFormat.Xml:
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Error), new XmlRootAttribute("result"));
            using (var source = new StringReader(response.Content))
            {
              error = serializer.Deserialize(source).To<Error>();
            }
            break;
        }
      }
      catch
      {
      }
      if (error != null && !error.Text.IsEmpty())
      {
        throw new RuLawException(error);
      }

      return response;
    }

    private RestRequest CreateRequest(string resource, IDictionary<string, object> parameters = null)
    {
      Assertion.NotEmpty(resource);

      var request = new RestRequest(string.Format(CultureInfo.InvariantCulture, "{0}.{1}", resource, this.format.ToString().ToLowerInvariant()));

      switch (this.format)
      {
        case ApiDataFormat.Json:
          request.RequestFormat = DataFormat.Json;
          request.JsonSerializer = this.jsonSerializer;
          break;

        case ApiDataFormat.Xml:
          request.RequestFormat = DataFormat.Xml;
          request.XmlSerializer = this.xmlSerializer;
          break;
      }

      if (parameters != null)
      {
        foreach (var parameter in parameters)
        {
          if (parameter.Value != null)
          {
            request.AddParameter(parameter.Key, parameter.Value.ToStringInvariant());
          }
        }
      }

      return request;
    }
  }
}