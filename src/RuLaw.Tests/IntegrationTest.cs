namespace RuLaw.Tests;

/// <summary>
///   <para></para>
/// </summary>
public class IntegrationTest : Test
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  protected IApi Api { get; } = null; //RuLaw.Api.Configure(configurator => configurator.ApiKey(/*ConfigurationManager.AppSettings["ApiKey"]*/"api").AppKey(ConfigurationManager.AppSettings["AppKey"]));

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override void Dispose()
  {
    base.Dispose();
    Api.Dispose();
  }
}