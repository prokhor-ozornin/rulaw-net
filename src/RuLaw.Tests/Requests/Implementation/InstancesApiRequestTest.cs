using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="InstancesApiRequest"/>.</para>
/// </summary>
public sealed class InstancesApiRequestTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="InstancesApiRequest()"/>
  [Fact]
  public void Constructors()
  {
    typeof(InstancesApiRequest).Should().BeDerivedFrom<ApiRequest>().And.Implement<IInstancesApiRequest>();

    var request = new InstancesApiRequest();
    request.Parameters.Should().BeEmpty();
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

      request.Parameters.Should().BeEmpty();

      request.Current(null).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["current"].Should().BeNull();

      request.Current().Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["current"].Should().Be(true.ToString());

      request.Current(false).Should().NotBeNull().And.BeSameAs(request);
      request.Parameters["current"].Should().Be(false.ToString());
    }

    return;

    static void Validate()
    {

    }
  }
}