using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
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
    typeof(DeputiesApiRequest).Should().BeDerivedFrom<ApiRequest>().And.Implement<IDeputiesApiRequest>();

    var request = new DeputiesApiRequest();
    request.Parameters.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputiesApiRequest.Name(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new DeputiesApiRequest(), null);
      Validate(string.Empty, new DeputiesApiRequest(), string.Empty);
      Validate("name", new DeputiesApiRequest(), "name");
    }

    return;

    static void Validate(string result, IDeputiesApiRequest request, string name) => request.Name(name).Should().BeSameAs(request).And.BeOfType<DeputiesApiRequest>().Which.Parameters["begin"].Should().Be(name).And.Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputiesApiRequest.Position(string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Position_Method()
  {
    using (new AssertionScope())
    {
      Validate(null, new DeputiesApiRequest(), null);
      Validate(string.Empty, new DeputiesApiRequest(), string.Empty);
      Validate("position", new DeputiesApiRequest(), "position");
    }

    return;

    static void Validate(string result, IDeputiesApiRequest request, string position) => request.Position(position).Should().BeSameAs(request).And.BeOfType<DeputiesApiRequest>().Which.Parameters["position"].Should().Be(position).And.Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DeputiesApiRequest.Current(bool?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Current_Method()
  {
    using (new AssertionScope())
    {
      var request = new DeputiesApiRequest();

      Validate(null, request);
      Validate(true, request);
      Validate(false, request);
    }

    return;

    static void Validate(bool? current, IDeputiesApiRequest request) => request.Current(current).Should().BeSameAs(request).And.BeOfType<DeputiesApiRequest>().Which.Parameters["current"].Should().Be(current?.ToString().ToLowerInvariant());
}
}