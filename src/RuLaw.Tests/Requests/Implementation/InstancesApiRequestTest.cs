using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="InstancesApiRequest"/>.</para>
/// </summary>
/// <seealso cref="InstancesApiRequest"/>
public sealed class InstancesApiRequestTest : Test
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="InstancesApiRequest()"/>
  [Fact]
  public void Constructors()
  {
    typeof(InstancesApiRequest).Should().BeDerivedFrom<ApiRequest>().And.Implement<IInstancesApiRequest>();

    using (new AssertionScope())
    {
      var request = new InstancesApiRequest();

      request.Parameters.Should().BeEmpty();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="InstancesApiRequest.Current(bool?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Current_Method()
  {
    using (new AssertionScope())
    {
      var request = new InstancesApiRequest();

      Test(null, request);
      Test(true, request);
      Test(false, request);
    }

    return;

    static void Test(bool? current, IInstancesApiRequest request) => request.Current(current).Should().BeSameAs(request).And.BeOfType<InstancesApiRequest>().Which.Parameters["current"].Should().Be(current?.ToString().ToLowerInvariant());
  }
}