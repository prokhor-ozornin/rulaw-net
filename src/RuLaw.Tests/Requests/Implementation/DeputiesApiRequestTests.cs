using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DeputiesApiRequest"/>.</para>
/// </summary>
public sealed class DeputiesApiRequestTests : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DeputiesApiRequest()"/>
  [Fact]
  public void Constructors()
  {
    var request = new DeputiesApiRequest();
    request.Parameters.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputiesApiRequest.Name(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    var request = new DeputiesApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Name(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["begin"].Should().BeNull();

    request.Name("name").Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["begin"].Should().Be("name");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputiesApiRequest.Position(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Position_Method()
  {
    var request = new DeputiesApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Position(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["position"].Should().BeNull();

    request.Position("first").Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["position"].Should().Be("first");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputiesApiRequest.Current(bool?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Current_Method()
  {
    var request = new DeputiesApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Current(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["current"].Should().BeNull();

    request.Current().Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["current"].Should().Be(true.ToString());

    request.Current(false).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["current"].Should().Be(false.ToString());
  }
}