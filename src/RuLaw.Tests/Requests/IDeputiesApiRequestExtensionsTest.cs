using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputiesApiRequestExtensions.Position(null, DeputyPosition.DumaDeputy)).ThrowExactly<ArgumentNullException>().WithParameterName("request");

      Validate(null, null, new DeputiesApiRequest());
      Validate("Депутат ГД", DeputyPosition.DumaDeputy, new DeputiesApiRequest());
      Validate("Член СФ", DeputyPosition.FederationCouncilMember, new DeputiesApiRequest());
    }

    return;

    static void Validate(string result, DeputyPosition? position, IDeputiesApiRequest request) => request.Position(position).Should().BeSameAs(request).And.BeOfType<DeputiesApiRequest>().Which.Parameters["position"].Should().Be(result);
  }
}