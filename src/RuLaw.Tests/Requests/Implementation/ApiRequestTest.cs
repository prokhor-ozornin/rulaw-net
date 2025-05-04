using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ApiRequest"/>.</para>
/// </summary>
public sealed class ApiRequestTest : Test
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="ApiRequest()"/>
  [Fact]
  public void Constructors()
  {
    typeof(ApiRequest).Should().BeDerivedFrom<object>().And.Implement<IApiRequest>();

    using (new AssertionScope())
    {
      var request = new TestApiRequest();

      request.Parameters.Should().BeEmpty();
    }
  }

  private sealed class TestApiRequest : ApiRequest
  {
  }
}