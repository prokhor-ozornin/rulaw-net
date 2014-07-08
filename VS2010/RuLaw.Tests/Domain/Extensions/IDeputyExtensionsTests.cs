using System;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IDeputyExtensions"/>.</para>
  /// </summary>
  public sealed class IDeputyExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="IDeputyExtensions.Position(IDeputy)"/> method.</para>
    /// </summary>
    [Fact]
    public void Position_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IDeputyExtensions.Position(null));

      Assert.Null(new Deputy().Position());
      Assert.Throws<InvalidOperationException>(() => new Deputy { Position = "position" }.Position());
      Assert.Equal(DeputyPosition.DumaDeputy, new Deputy { Position = "Депутат ГД" }.Position());
      Assert.Equal(DeputyPosition.FederationCouncilMember, new Deputy { Position = "Член СФ" }.Position());
    }
  }
}