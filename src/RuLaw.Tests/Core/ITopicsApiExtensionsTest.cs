using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests.Core;

/// <summary>
///   <para>Tests set for class <see cref="ITopicsApiExtensions"/>.</para>
/// </summary>
/// <seealso cref="ITopicsApiExtensions"/>
public sealed class ITopicsApiExtensionsTest : IntegrationTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ITopicsApiExtensions.All(ITopicsApi)"/> method.</para>
  /// </summary>
  [Fact]
  public void All_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ITopicsApiExtensions.All(null)).ThrowExactly<ArgumentNullException>().WithParameterName("api");

      Test(Api.Topics.All());
    }

    return;

    static void Test(IEnumerable<ITopic> topics)
    {
      topics.Should().BeOfType<List<Topic>>().And.NotBeEmpty();
      
      var topic = topics.Single(topic => topic.Id == 62701);
      topic.Name.Should().Be("Бюджетное, налоговое, финансовое законодательство");
    }
  }
}