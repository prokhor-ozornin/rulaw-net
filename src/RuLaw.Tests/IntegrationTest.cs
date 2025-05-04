namespace RuLaw.Tests;

public class IntegrationTest : Test
{
  protected IApi Api { get; } = null; //RuLaw.Api.Configure(configurator => configurator.ApiKey(/*ConfigurationManager.AppSettings["ApiKey"]*/"api").AppKey(ConfigurationManager.AppSettings["AppKey"]));

  public override void Dispose()
  {
    base.Dispose();
    Api.Dispose();
  }
}