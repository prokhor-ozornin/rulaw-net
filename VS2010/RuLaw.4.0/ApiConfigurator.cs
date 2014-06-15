using Catharsis.Commons;

namespace RuLaw
{
  internal sealed class ApiConfigurator : IApiConfigurator
  {
    private ApiDataFormat format = ApiDataFormat.Json;
    private string apiKey;
    private string appKey;

    public IApiConfigurator Format(ApiDataFormat format)
    {
      this.format = format;
      return this;
    }

    public IApiConfigurator ApiKey(string key)
    {
      Assertion.NotEmpty(key);

      this.apiKey = key;
      return this;
    }

    public IApiConfigurator AppKey(string key)
    {
      Assertion.NotEmpty(key);

      this.appKey = key;
      return this;
    }

    public string GetApiKey()
    {
      return this.apiKey;
    }

    public string GetAppKey()
    {
      return this.appKey;
    }

    public ApiDataFormat GetFormat()
    {
      return this.format;
    }
  }
}