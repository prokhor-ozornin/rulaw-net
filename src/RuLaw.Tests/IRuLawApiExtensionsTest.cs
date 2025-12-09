using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IRuLawApiExtensions"/>.</para>
/// </summary>
/// <seealso cref="IRuLawApiExtensions"/>
public sealed class IRuLawApiExtensionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IRuLawApiExtensions.Configure(IRuLawApi, Action{IApiConfigurator})"/> method.</para>
  /// </summary>
  [Fact]
  public void Configure_Method()
  {
    using (new AssertionScope())
    {
      //AssertionExtensions.Should(() => IRuLawApiExtensions.Configure(null, _ => {})).ThrowExactly<ArgumentNullException>().WithParameterName("api");
      //AssertionExtensions.Should(() => IRuLawApiExtensions.Configure(RuLaw.Api, null)).ThrowExactly<ArgumentNullException>().WithParameterName("action");
      //AssertionExtensions.Should(() => RuLaw.Api.Configure(_ => {})).ThrowExactly<InvalidOperationException>();
      
      Test(RuLaw.Api);
    }

    return;

    static void Test(IRuLawApi api)
    {
      var result = api.Configure(configurator => configurator.ApiKey("apiKey").AppKey("appKey")).Should().BeOfType<Api>();
      result.GetPropertyValue<string>("ApiToken").Should().Be("apiKey");
      result.GetPropertyValue<string>("AppToken").Should().Be("appKey");
    }
  }
}