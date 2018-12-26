namespace RuLaw
{
  using Catharsis.Commons;

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

      apiKey = key;
      return this;
    }

    public IApiConfigurator AppKey(string key)
    {
      Assertion.NotEmpty(key);

      appKey = key;
      return this;
    }

    public string GetApiKey()
    {
      return apiKey;
    }

    public string GetAppKey()
    {
      return appKey;
    }

    public ApiDataFormat GetFormat()
    {
      return format;
    }
  }
}