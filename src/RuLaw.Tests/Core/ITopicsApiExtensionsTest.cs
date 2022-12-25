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

  private CancellationToken Cancellation { get; } = new(true);

    /// <summary>
  ///   <para>Performs testing of <see cref="ITopicsApiExtensions.All(ITopicsApi, out IEnumerable{ITopic}?, CancellationToken)"/> method.</para>
  /// </summary>
  [Fact]
  public void All_Method()
  {
    AssertionExtensions.Should(() => ITopicsApiExtensions.All(null!, out _)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Api.Topics.All(out _, Cancellation)).ThrowExactly<TaskCanceledException>();

    Api.Topics.All(out var topics).Should().BeTrue();
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