using System;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IDeputiesLawApiCallExtensions"/>.</para>
  /// </summary>
  public sealed class IDeputiesLawApiCallExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="IDeputiesLawApiCallExtensions.Position(IDeputiesLawApiCall, DeputyPosition)"/> method.</para>
    /// </summary>
    [Fact]
    public void Position_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IDeputiesLawApiCallExtensions.Position(null, DeputyPosition.DumaDeputy));

      var call = new DeputiesLawApiCall();
      Assert.True(ReferenceEquals(call.Position(DeputyPosition.DumaDeputy), call));
      Assert.Equal("Депутат ГД", call.Parameters["position"]);
      Assert.Equal("Член СФ", call.Position(DeputyPosition.FederationCouncilMember).Parameters["position"]);
    }
  }
}