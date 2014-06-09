using System;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="RuLaw"/>.</para>
  /// </summary>
  public sealed class RuLawTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="RuLaw.API(Action{IApiConfigurator})"/> method.</para>
    /// </summary>
    [Fact]
    public void API_Method()
    {
      Assert.Throws<ArgumentNullException>(() => RuLaw.API(null));
      Assert.Throws<RuLawException>(() => RuLaw.API(configurator => { }));
      
      var caller = RuLaw.API(configurator => configurator.ApiKey("apiKey"));
      Assert.Equal("apiKey", caller.ApiToken);
      Assert.Null(caller.AppToken);
      Assert.Equal(ApiDataFormat.Json, caller.Field("format").To<ApiDataFormat>());

      caller = RuLaw.API(configurator => configurator.ApiKey("apiKey").AppKey("appKey").Format(ApiDataFormat.Xml));
      Assert.Equal("apiKey", caller.ApiToken);
      Assert.Equal("appKey", caller.AppToken);
      Assert.Equal(ApiDataFormat.Xml, caller.Field("format").To<ApiDataFormat>());
    }
  }
}