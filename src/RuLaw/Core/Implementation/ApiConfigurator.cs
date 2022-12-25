namespace RuLaw;

internal sealed class ApiConfigurator : IApiConfigurator
{
  public string? ApiKeyValue { get; private set; }

  public string? AppKeyValue { get; private set; }

  public IApiConfigurator ApiKey(string? key)
  {
    ApiKeyValue = key;

    return this;
  }

  public IApiConfigurator AppKey(string? key)
  {
    AppKeyValue = key;

    return this;
  }
}