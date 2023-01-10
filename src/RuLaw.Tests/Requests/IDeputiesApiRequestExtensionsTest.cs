using FluentAssertions;
using Xunit;

namespace RuLaw.Tests.Calls;

/// <summary>
///   <para>Tests set for class <see cref="IDeputiesApiRequestExtensions"/>.</para>
/// </summary>
public sealed class IDeputiesLawApiCallExtensionsTests : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IDeputiesApiRequestExtensions.Position(IDeputiesApiRequest, DeputyPosition?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Position_Method()
  {
    AssertionExtensions.Should(() => IDeputiesApiRequestExtensions.Position(null, DeputyPosition.DumaDeputy)).ThrowExactly<ArgumentNullException>().WithParameterName("request");

    var request = new DeputiesApiRequest();

    request.Parameters.Should().BeEmpty();

    request.Position(null).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["position"].Should().BeNull();

    request.Position(DeputyPosition.DumaDeputy).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["position"].Should().Be("Депутат ГД");

    request.Position(DeputyPosition.FederationCouncilMember).Should().NotBeNull().And.BeSameAs(request);
    request.Parameters["position"].Should().Be("Член СФ");
  }
}