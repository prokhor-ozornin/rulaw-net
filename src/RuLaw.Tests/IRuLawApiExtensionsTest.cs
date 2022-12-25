using FluentAssertions;
using Xunit;
using Catharsis.Commons;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IRuLawApiExtensions"/>.</para>
/// </summary>
public sealed class IRuLawApiExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IRuLawApiExtensions.Configure(IRuLawApi, Action{IApiConfigurator})"/> method.</para>
  /// </summary>
  [Fact]
  public void Configure_Method()
  {
    AssertionExtensions.Should(() => IRuLawApiExtensions.Configure(null!, _ => {})).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => IRuLawApiExtensions.Configure(RuLaw.Api, null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => RuLaw.Api.Configure(_ => {})).ThrowExactly<InvalidOperationException>();

    var api = RuLaw.Api.Configure(configurator => configurator.ApiKey("apiKey").AppKey("appKey"));
    api.Should().NotBeNull().And.BeOfType<Api>();
    api.Property("ApiToken").Should().Be("apiKey");
    api.Property("AppToken").Should().Be("appKey");
  }
}