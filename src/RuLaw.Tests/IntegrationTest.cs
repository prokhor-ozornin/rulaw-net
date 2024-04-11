using System.Configuration;
using Catharsis.Commons;

namespace RuLaw.Tests;

public class IntegrationTest<T> : ClassTest<T>
{
  protected IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(/*ConfigurationManager.AppSettings["ApiKey"]*/"api").AppKey(ConfigurationManager.AppSettings["AppKey"]));

  public override void Dispose()
  {
    base.Dispose();
    Api.Dispose();
  }
}

public class IntegrationTest : IntegrationTest<object>
{
}