using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ApiConfigurator"/>.</para>
/// </summary>
public sealed class ApiConfiguratorTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="ApiConfigurator()"/>
  [Fact]
  public void Constructors()
  {
    typeof(ApiConfigurator).Should().BeDerivedFrom<object>().And.Implement<IApiConfigurator>();

    var configurator = new ApiConfigurator();
    configurator.ApiKeyValue.Should().BeNull();
    configurator.AppKeyValue.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ApiConfigurator.ApiKey(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ApiKey_Method()
  {
    using (new AssertionScope())
    {
      Validate(new ApiConfigurator(), "apiKey");
    }

    return;

    static void Validate(IApiConfigurator configurator, string key) => configurator.ApiKey(key).Should().BeSameAs(configurator).And.BeOfType<ApiConfigurator>().Which.ApiKeyValue.Should().Be(key);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ApiConfigurator.AppKey(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void AppKey_Method()
  {
    using (new AssertionScope())
    {
      Validate(new ApiConfigurator(), "appKey");
    }

    return;

    static void Validate(IApiConfigurator configurator, string key) => configurator.AppKey(key).Should().BeSameAs(configurator).And.BeOfType<ApiConfigurator>().Which.AppKeyValue.Should().Be(key);
  }
}