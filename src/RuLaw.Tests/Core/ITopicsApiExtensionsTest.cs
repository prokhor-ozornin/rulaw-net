using System.Configuration;
using FluentAssertions;
using Xunit;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="ITopicsApiExtensions"/>.</para>
/// </summary>
public sealed class ITopicsApiExtensionsTest : IDisposable
{
  private IApi Api { get; } = RuLaw.Api.Configure(configurator => configurator.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]));

  /// <summary>
  ///   <para>Performs testing of <see cref="ITopicsApiExtensions.All(ITopicsApi)"/> method.</para>
  /// </summary>
  [Fact]
  public void All_Method()
  {
    AssertionExtensions.Should(() => ITopicsApiExtensions.All(null)).ThrowExactly<ArgumentNullException>();

    var topics = Api.Topics.All();
    topics.Should().NotBeNullOrEmpty().And.BeOfType<List<Topic>>().And.ContainSingle(topic => topic.Id == 62701).Which.Name.Should().Be("Бюджетное, налоговое, финансовое законодательство");
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public void Dispose()
  {
    Api.Dispose();
  }
}