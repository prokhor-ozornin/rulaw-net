using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IDeputyExtensions"/>.</para>
/// </summary>
public sealed class IDeputyExtensionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="IDeputyExtensions.Position(IDeputy)"/></description></item>
  ///     <item><description><see cref="IDeputyExtensions.Position{TEntity}(IEnumerable{TEntity}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Position_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyExtensions.Position(null)).ThrowExactly<ArgumentNullException>().WithParameterName("deputy");

      Test(null, new Deputy());
      Test(DeputyPosition.DumaDeputy, new Deputy { Position = "Депутат ГД" });
      Test(DeputyPosition.FederationCouncilMember, new Deputy { Position = "Член СФ" });

      static void Test(DeputyPosition? result, IDeputy deputy) => deputy.Position().Should().Be(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDeputyExtensions.Position<IDeputy>(null, "position")).ThrowExactly<ArgumentNullException>().WithParameterName("deputies");

      Test([], [], null);
      Test([], [], "position");
      
      var first = new Deputy { Position = "first" };
      var second = new Deputy { Position = "second" };
      Test([], [null], null);
      Test([first], [null, first, second, null], first.Position);

      static void Test(IEnumerable<IDeputy> result, IEnumerable<IDeputy> deputies, string position) => deputies.Position(position).Should().BeAssignableTo<IEnumerable<IDeputy>>().And.Equal(result);
    }
  }
}