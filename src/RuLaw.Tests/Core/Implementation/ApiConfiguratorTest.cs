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
      AssertionExtensions.Should(() => new ApiConfigurator().ApiKey(null)).ThrowExactly<ArgumentNullException>().WithParameterName("key");
      AssertionExtensions.Should(() => new ApiConfigurator().ApiKey(string.Empty)).ThrowExactly<ArgumentException>().WithParameterName("key");

      var configurator = new ApiConfigurator();
      configurator.ApiKey("apiKey").Should().NotBeNull().And.BeSameAs(configurator);
      configurator.ApiKeyValue.Should().Be("apiKey");
    }

    return;

    static void Validate()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ApiConfigurator.AppKey(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void AppKey_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => new ApiConfigurator().AppKey(null)).ThrowExactly<ArgumentNullException>().WithParameterName("key");
      AssertionExtensions.Should(() => new ApiConfigurator().AppKey(string.Empty)).ThrowExactly<ArgumentException>().WithParameterName("key");

      var configurator = new ApiConfigurator();
      configurator.AppKey("appKey").Should().NotBeNull().And.BeSameAs(configurator);
      configurator.AppKeyValue.Should().Be("appKey");
    }

    return;

    static void Validate()
    {

    }
  }
}